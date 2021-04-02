using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.PositionInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class PositionInfoApiTest
    {
        private PositionInfoController _controller;
        private string _seed;

        public PositionInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<PositionInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new PositionInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            PositionInfoVM vm = _controller.Wtm.CreateVM<PositionInfoVM>();
            PositionInfo v = new PositionInfo();
            
            v.ID = 74;
            v.Code = "KVjSXBDc";
            v.Name = "ORd2oEZlh";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PositionInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 74);
                Assert.AreEqual(data.Code, "KVjSXBDc");
                Assert.AreEqual(data.Name, "ORd2oEZlh");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            PositionInfo v = new PositionInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 74;
                v.Code = "KVjSXBDc";
                v.Name = "ORd2oEZlh";
                context.Set<PositionInfo>().Add(v);
                context.SaveChanges();
            }

            PositionInfoVM vm = _controller.Wtm.CreateVM<PositionInfoVM>();
            var oldID = v.ID;
            v = new PositionInfo();
            v.ID = oldID;
       		
            v.Code = "oDuObQ";
            v.Name = "5Vsm";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PositionInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "oDuObQ");
                Assert.AreEqual(data.Name, "5Vsm");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            PositionInfo v = new PositionInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 74;
                v.Code = "KVjSXBDc";
                v.Name = "ORd2oEZlh";
                context.Set<PositionInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PositionInfo v1 = new PositionInfo();
            PositionInfo v2 = new PositionInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 74;
                v1.Code = "KVjSXBDc";
                v1.Name = "ORd2oEZlh";
                v2.ID = 28;
                v2.Code = "oDuObQ";
                v2.Name = "5Vsm";
                context.Set<PositionInfo>().Add(v1);
                context.Set<PositionInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<PositionInfo>().Find(v1.ID);
                var data2 = context.Set<PositionInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
