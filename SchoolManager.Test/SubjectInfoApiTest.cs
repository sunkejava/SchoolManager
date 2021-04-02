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
            
            v.ID = 56;
            v.Code = "6qcCQNHhv";
            v.Name = "LgW1HXAB";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SubjectInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 56);
                Assert.AreEqual(data.Code, "6qcCQNHhv");
                Assert.AreEqual(data.Name, "LgW1HXAB");
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
       			
                v.ID = 56;
                v.Code = "6qcCQNHhv";
                v.Name = "LgW1HXAB";
                context.Set<SubjectInfo>().Add(v);
                context.SaveChanges();
            }

            SubjectInfoVM vm = _controller.Wtm.CreateVM<SubjectInfoVM>();
            var oldID = v.ID;
            v = new SubjectInfo();
            v.ID = oldID;
       		
            v.Code = "JmC7j";
            v.Name = "8ijcjM3j";
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
 				
                Assert.AreEqual(data.Code, "JmC7j");
                Assert.AreEqual(data.Name, "8ijcjM3j");
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
        		
                v.ID = 56;
                v.Code = "6qcCQNHhv";
                v.Name = "LgW1HXAB";
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
				
                v1.ID = 56;
                v1.Code = "6qcCQNHhv";
                v1.Name = "LgW1HXAB";
                v2.ID = 57;
                v2.Code = "JmC7j";
                v2.Name = "8ijcjM3j";
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
