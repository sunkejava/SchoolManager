using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.GradeClassInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class GradeClassInfoApiTest
    {
        private GradeClassInfoController _controller;
        private string _seed;

        public GradeClassInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<GradeClassInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new GradeClassInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            GradeClassInfoVM vm = _controller.Wtm.CreateVM<GradeClassInfoVM>();
            GradeClassInfo v = new GradeClassInfo();
            
            v.ID = 51;
            v.Code = "FRMl5";
            v.GradeId = AddGrade();
            v.Name = "bfJXKT";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GradeClassInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 51);
                Assert.AreEqual(data.Code, "FRMl5");
                Assert.AreEqual(data.Name, "bfJXKT");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            GradeClassInfo v = new GradeClassInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 51;
                v.Code = "FRMl5";
                v.GradeId = AddGrade();
                v.Name = "bfJXKT";
                context.Set<GradeClassInfo>().Add(v);
                context.SaveChanges();
            }

            GradeClassInfoVM vm = _controller.Wtm.CreateVM<GradeClassInfoVM>();
            var oldID = v.ID;
            v = new GradeClassInfo();
            v.ID = oldID;
       		
            v.Code = "EUInO7L";
            v.Name = "CXRL";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.GradeId", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GradeClassInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "EUInO7L");
                Assert.AreEqual(data.Name, "CXRL");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            GradeClassInfo v = new GradeClassInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 51;
                v.Code = "FRMl5";
                v.GradeId = AddGrade();
                v.Name = "bfJXKT";
                context.Set<GradeClassInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            GradeClassInfo v1 = new GradeClassInfo();
            GradeClassInfo v2 = new GradeClassInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 51;
                v1.Code = "FRMl5";
                v1.GradeId = AddGrade();
                v1.Name = "bfJXKT";
                v2.ID = 68;
                v2.Code = "EUInO7L";
                v2.GradeId = v1.GradeId; 
                v2.Name = "CXRL";
                context.Set<GradeClassInfo>().Add(v1);
                context.Set<GradeClassInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<GradeClassInfo>().Find(v1.ID);
                var data2 = context.Set<GradeClassInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Int32 AddGrade()
        {
            GradeInfo v = new GradeInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 4;
                v.Code = "zfjpB";
                v.Name = "LWsN";
                context.Set<GradeInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
