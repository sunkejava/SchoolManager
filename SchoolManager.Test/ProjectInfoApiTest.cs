using Microsoft.AspNetCore.Mvc;
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
            
            v.ID = 50;
            v.Code = "8zD";
            v.Name = "kG7";
            v.TypeOfProject = SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Teacher;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProjectInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 50);
                Assert.AreEqual(data.Code, "8zD");
                Assert.AreEqual(data.Name, "kG7");
                Assert.AreEqual(data.TypeOfProject, SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Teacher);
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
       			
                v.ID = 50;
                v.Code = "8zD";
                v.Name = "kG7";
                v.TypeOfProject = SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Teacher;
                context.Set<ProjectInfo>().Add(v);
                context.SaveChanges();
            }

            ProjectInfoVM vm = _controller.Wtm.CreateVM<ProjectInfoVM>();
            var oldID = v.ID;
            v = new ProjectInfo();
            v.ID = oldID;
       		
            v.Code = "b84dLS0";
            v.Name = "oxiWUh";
            v.TypeOfProject = SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Student;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.TypeOfProject", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProjectInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "b84dLS0");
                Assert.AreEqual(data.Name, "oxiWUh");
                Assert.AreEqual(data.TypeOfProject, SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Student);
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
        		
                v.ID = 50;
                v.Code = "8zD";
                v.Name = "kG7";
                v.TypeOfProject = SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Teacher;
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
				
                v1.ID = 50;
                v1.Code = "8zD";
                v1.Name = "kG7";
                v1.TypeOfProject = SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Teacher;
                v2.ID = 75;
                v2.Code = "b84dLS0";
                v2.Name = "oxiWUh";
                v2.TypeOfProject = SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Student;
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
