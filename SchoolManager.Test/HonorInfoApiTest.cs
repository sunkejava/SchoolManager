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
            
            v.ID = 19;
            v.Code = "G4QoS";
            v.Name = "LkW1p";
            v.TypeOfHonor = SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Student;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<HonorInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 19);
                Assert.AreEqual(data.Code, "G4QoS");
                Assert.AreEqual(data.Name, "LkW1p");
                Assert.AreEqual(data.TypeOfHonor, SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Student);
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
       			
                v.ID = 19;
                v.Code = "G4QoS";
                v.Name = "LkW1p";
                v.TypeOfHonor = SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Student;
                context.Set<HonorInfo>().Add(v);
                context.SaveChanges();
            }

            HonorInfoVM vm = _controller.Wtm.CreateVM<HonorInfoVM>();
            var oldID = v.ID;
            v = new HonorInfo();
            v.ID = oldID;
       		
            v.Code = "dDu4j";
            v.Name = "Y5nKI";
            v.TypeOfHonor = SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Student;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.TypeOfHonor", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<HonorInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "dDu4j");
                Assert.AreEqual(data.Name, "Y5nKI");
                Assert.AreEqual(data.TypeOfHonor, SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Student);
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
        		
                v.ID = 19;
                v.Code = "G4QoS";
                v.Name = "LkW1p";
                v.TypeOfHonor = SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Student;
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
				
                v1.ID = 19;
                v1.Code = "G4QoS";
                v1.Name = "LkW1p";
                v1.TypeOfHonor = SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Student;
                v2.ID = 11;
                v2.Code = "dDu4j";
                v2.Name = "Y5nKI";
                v2.TypeOfHonor = SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Student;
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
