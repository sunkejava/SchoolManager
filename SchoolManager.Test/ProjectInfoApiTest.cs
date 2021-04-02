﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Basic.ProjectInfoVMs;
using SchoolManager.Model.BasicInfo;
using SchoolManager.DataAccess;


namespace SchoolManager.Test
{
    [TestClass]
    public class ProjectInfoApiTest
    {
        private ProjectInfoController _controller;
        private string _seed;

        public ProjectInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProjectInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProjectInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProjectInfoVM vm = _controller.Wtm.CreateVM<ProjectInfoVM>();
            ProjectInfo v = new ProjectInfo();
            
            v.ID = 47;
            v.Code = "VYZd2SHLr";
            v.Name = "HjOEbo1";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProjectInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 47);
                Assert.AreEqual(data.Code, "VYZd2SHLr");
                Assert.AreEqual(data.Name, "HjOEbo1");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ProjectInfo v = new ProjectInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 47;
                v.Code = "VYZd2SHLr";
                v.Name = "HjOEbo1";
                context.Set<ProjectInfo>().Add(v);
                context.SaveChanges();
            }

            ProjectInfoVM vm = _controller.Wtm.CreateVM<ProjectInfoVM>();
            var oldID = v.ID;
            v = new ProjectInfo();
            v.ID = oldID;
       		
            v.Code = "kSdfSNdm";
            v.Name = "JYMgCJ02y";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProjectInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "kSdfSNdm");
                Assert.AreEqual(data.Name, "JYMgCJ02y");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ProjectInfo v = new ProjectInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 47;
                v.Code = "VYZd2SHLr";
                v.Name = "HjOEbo1";
                context.Set<ProjectInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProjectInfo v1 = new ProjectInfo();
            ProjectInfo v2 = new ProjectInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 47;
                v1.Code = "VYZd2SHLr";
                v1.Name = "HjOEbo1";
                v2.ID = 74;
                v2.Code = "kSdfSNdm";
                v2.Name = "JYMgCJ02y";
                context.Set<ProjectInfo>().Add(v1);
                context.Set<ProjectInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ProjectInfo>().Find(v1.ID);
                var data2 = context.Set<ProjectInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
