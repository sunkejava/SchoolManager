using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.MajorInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class MajorInfoApiTest
    {
        private MajorInfoController _controller;
        private string _seed;

        public MajorInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<MajorInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new MajorInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            MajorInfoVM vm = _controller.Wtm.CreateVM<MajorInfoVM>();
            MajorInfo v = new MajorInfo();
            
            v.ID = 97;
            v.Code = "OvF";
            v.Name = "YTWPQ2Nb";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<MajorInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 97);
                Assert.AreEqual(data.Code, "OvF");
                Assert.AreEqual(data.Name, "YTWPQ2Nb");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            MajorInfo v = new MajorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 97;
                v.Code = "OvF";
                v.Name = "YTWPQ2Nb";
                context.Set<MajorInfo>().Add(v);
                context.SaveChanges();
            }

            MajorInfoVM vm = _controller.Wtm.CreateVM<MajorInfoVM>();
            var oldID = v.ID;
            v = new MajorInfo();
            v.ID = oldID;
       		
            v.Code = "Am0";
            v.Name = "Ids";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<MajorInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "Am0");
                Assert.AreEqual(data.Name, "Ids");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            MajorInfo v = new MajorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 97;
                v.Code = "OvF";
                v.Name = "YTWPQ2Nb";
                context.Set<MajorInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            MajorInfo v1 = new MajorInfo();
            MajorInfo v2 = new MajorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 97;
                v1.Code = "OvF";
                v1.Name = "YTWPQ2Nb";
                v2.ID = 39;
                v2.Code = "Am0";
                v2.Name = "Ids";
                context.Set<MajorInfo>().Add(v1);
                context.Set<MajorInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<MajorInfo>().Find(v1.ID);
                var data2 = context.Set<MajorInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
