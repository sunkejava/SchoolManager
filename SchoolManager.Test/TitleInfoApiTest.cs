using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.TitleInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class TitleInfoApiTest
    {
        private TitleInfoController _controller;
        private string _seed;

        public TitleInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<TitleInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new TitleInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            TitleInfoVM vm = _controller.Wtm.CreateVM<TitleInfoVM>();
            TitleInfo v = new TitleInfo();
            
            v.ID = 89;
            v.Code = "TLbJgMX5i";
            v.Name = "cclfWj";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TitleInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 89);
                Assert.AreEqual(data.Code, "TLbJgMX5i");
                Assert.AreEqual(data.Name, "cclfWj");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            TitleInfo v = new TitleInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 89;
                v.Code = "TLbJgMX5i";
                v.Name = "cclfWj";
                context.Set<TitleInfo>().Add(v);
                context.SaveChanges();
            }

            TitleInfoVM vm = _controller.Wtm.CreateVM<TitleInfoVM>();
            var oldID = v.ID;
            v = new TitleInfo();
            v.ID = oldID;
       		
            v.Code = "26N";
            v.Name = "gW9NxOZ";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TitleInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "26N");
                Assert.AreEqual(data.Name, "gW9NxOZ");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            TitleInfo v = new TitleInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 89;
                v.Code = "TLbJgMX5i";
                v.Name = "cclfWj";
                context.Set<TitleInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            TitleInfo v1 = new TitleInfo();
            TitleInfo v2 = new TitleInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 89;
                v1.Code = "TLbJgMX5i";
                v1.Name = "cclfWj";
                v2.ID = 34;
                v2.Code = "26N";
                v2.Name = "gW9NxOZ";
                context.Set<TitleInfo>().Add(v1);
                context.Set<TitleInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<TitleInfo>().Find(v1.ID);
                var data2 = context.Set<TitleInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
