using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.SubjectInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class SubjectInfoApiTest
    {
        private SubjectInfoController _controller;
        private string _seed;

        public SubjectInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<SubjectInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new SubjectInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            SubjectInfoVM vm = _controller.Wtm.CreateVM<SubjectInfoVM>();
            SubjectInfo v = new SubjectInfo();
            
            v.ID = 54;
            v.Code = "nDlt79A";
            v.Name = "9KTUiITG";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SubjectInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 54);
                Assert.AreEqual(data.Code, "nDlt79A");
                Assert.AreEqual(data.Name, "9KTUiITG");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            SubjectInfo v = new SubjectInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 54;
                v.Code = "nDlt79A";
                v.Name = "9KTUiITG";
                context.Set<SubjectInfo>().Add(v);
                context.SaveChanges();
            }

            SubjectInfoVM vm = _controller.Wtm.CreateVM<SubjectInfoVM>();
            var oldID = v.ID;
            v = new SubjectInfo();
            v.ID = oldID;
       		
            v.Code = "zwbHg8";
            v.Name = "K9arMwfyt";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SubjectInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "zwbHg8");
                Assert.AreEqual(data.Name, "K9arMwfyt");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            SubjectInfo v = new SubjectInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 54;
                v.Code = "nDlt79A";
                v.Name = "9KTUiITG";
                context.Set<SubjectInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            SubjectInfo v1 = new SubjectInfo();
            SubjectInfo v2 = new SubjectInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 54;
                v1.Code = "nDlt79A";
                v1.Name = "9KTUiITG";
                v2.ID = 31;
                v2.Code = "zwbHg8";
                v2.Name = "K9arMwfyt";
                context.Set<SubjectInfo>().Add(v1);
                context.Set<SubjectInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SubjectInfo>().Find(v1.ID);
                var data2 = context.Set<SubjectInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
