using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.GradeInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class GradeInfoApiTest
    {
        private GradeInfoController _controller;
        private string _seed;

        public GradeInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<GradeInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new GradeInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            GradeInfoVM vm = _controller.Wtm.CreateVM<GradeInfoVM>();
            GradeInfo v = new GradeInfo();
            
            v.ID = 14;
            v.Code = "lPxmir";
            v.Name = "fg6w922S0";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GradeInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 14);
                Assert.AreEqual(data.Code, "lPxmir");
                Assert.AreEqual(data.Name, "fg6w922S0");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            GradeInfo v = new GradeInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 14;
                v.Code = "lPxmir";
                v.Name = "fg6w922S0";
                context.Set<GradeInfo>().Add(v);
                context.SaveChanges();
            }

            GradeInfoVM vm = _controller.Wtm.CreateVM<GradeInfoVM>();
            var oldID = v.ID;
            v = new GradeInfo();
            v.ID = oldID;
       		
            v.Code = "1MYfrvms";
            v.Name = "5fNg07pI";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GradeInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "1MYfrvms");
                Assert.AreEqual(data.Name, "5fNg07pI");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            GradeInfo v = new GradeInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 14;
                v.Code = "lPxmir";
                v.Name = "fg6w922S0";
                context.Set<GradeInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            GradeInfo v1 = new GradeInfo();
            GradeInfo v2 = new GradeInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 14;
                v1.Code = "lPxmir";
                v1.Name = "fg6w922S0";
                v2.ID = 85;
                v2.Code = "1MYfrvms";
                v2.Name = "5fNg07pI";
                context.Set<GradeInfo>().Add(v1);
                context.Set<GradeInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<GradeInfo>().Find(v1.ID);
                var data2 = context.Set<GradeInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
