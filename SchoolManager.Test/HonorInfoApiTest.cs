using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.HonorInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class HonorInfoApiTest
    {
        private HonorInfoController _controller;
        private string _seed;

        public HonorInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<HonorInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new HonorInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            HonorInfoVM vm = _controller.Wtm.CreateVM<HonorInfoVM>();
            HonorInfo v = new HonorInfo();
            
            v.ID = 30;
            v.Code = "aRQqBKB";
            v.Name = "S4GbWITBk";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<HonorInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 30);
                Assert.AreEqual(data.Code, "aRQqBKB");
                Assert.AreEqual(data.Name, "S4GbWITBk");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            HonorInfo v = new HonorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 30;
                v.Code = "aRQqBKB";
                v.Name = "S4GbWITBk";
                context.Set<HonorInfo>().Add(v);
                context.SaveChanges();
            }

            HonorInfoVM vm = _controller.Wtm.CreateVM<HonorInfoVM>();
            var oldID = v.ID;
            v = new HonorInfo();
            v.ID = oldID;
       		
            v.Code = "9eU6bkjSA";
            v.Name = "wWha";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<HonorInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "9eU6bkjSA");
                Assert.AreEqual(data.Name, "wWha");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            HonorInfo v = new HonorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 30;
                v.Code = "aRQqBKB";
                v.Name = "S4GbWITBk";
                context.Set<HonorInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            HonorInfo v1 = new HonorInfo();
            HonorInfo v2 = new HonorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 30;
                v1.Code = "aRQqBKB";
                v1.Name = "S4GbWITBk";
                v2.ID = 83;
                v2.Code = "9eU6bkjSA";
                v2.Name = "wWha";
                context.Set<HonorInfo>().Add(v1);
                context.Set<HonorInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<HonorInfo>().Find(v1.ID);
                var data2 = context.Set<HonorInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
