using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.DivisionVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class DivisionApiTest
    {
        private DivisionController _controller;
        private string _seed;

        public DivisionApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<DivisionController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new DivisionSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            DivisionVM vm = _controller.Wtm.CreateVM<DivisionVM>();
            Division v = new Division();
            
            v.ID = 86;
            v.Code = "yOher";
            v.ParentCode = "dIt";
            v.RuralCode = "Sz3";
            v.Name = "s8W";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Division>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 86);
                Assert.AreEqual(data.Code, "yOher");
                Assert.AreEqual(data.ParentCode, "dIt");
                Assert.AreEqual(data.RuralCode, "Sz3");
                Assert.AreEqual(data.Name, "s8W");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Division v = new Division();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 86;
                v.Code = "yOher";
                v.ParentCode = "dIt";
                v.RuralCode = "Sz3";
                v.Name = "s8W";
                context.Set<Division>().Add(v);
                context.SaveChanges();
            }

            DivisionVM vm = _controller.Wtm.CreateVM<DivisionVM>();
            var oldID = v.ID;
            v = new Division();
            v.ID = oldID;
       		
            v.Code = "OOo90B";
            v.ParentCode = "KC5NKKyBW";
            v.RuralCode = "uCZ";
            v.Name = "Np4";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.ParentCode", "");
            vm.FC.Add("Entity.RuralCode", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Division>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "OOo90B");
                Assert.AreEqual(data.ParentCode, "KC5NKKyBW");
                Assert.AreEqual(data.RuralCode, "uCZ");
                Assert.AreEqual(data.Name, "Np4");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Division v = new Division();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 86;
                v.Code = "yOher";
                v.ParentCode = "dIt";
                v.RuralCode = "Sz3";
                v.Name = "s8W";
                context.Set<Division>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Division v1 = new Division();
            Division v2 = new Division();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 86;
                v1.Code = "yOher";
                v1.ParentCode = "dIt";
                v1.RuralCode = "Sz3";
                v1.Name = "s8W";
                v2.ID = 68;
                v2.Code = "OOo90B";
                v2.ParentCode = "KC5NKKyBW";
                v2.RuralCode = "uCZ";
                v2.Name = "Np4";
                context.Set<Division>().Add(v1);
                context.Set<Division>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Division>().Find(v1.ID);
                var data2 = context.Set<Division>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
