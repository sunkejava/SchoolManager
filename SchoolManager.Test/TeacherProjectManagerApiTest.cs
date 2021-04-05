using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Common.TeacherProjectManagerVMs;
using SchoolManager.Model.Business;
using SchoolManager.DataAccess;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.Test
{
    [TestClass]
    public class TeacherProjectManagerApiTest
    {
        private TeacherProjectManagerController _controller;
        private string _seed;

        public TeacherProjectManagerApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<TeacherProjectManagerController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new TeacherProjectManagerSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            TeacherProjectManagerVM vm = _controller.Wtm.CreateVM<TeacherProjectManagerVM>();
            TeacherProjectManager v = new TeacherProjectManager();
            
            v.ID = 93;
            v.ProjectId = AddProject();
            v.TeacherId = AddTeacher();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TeacherProjectManager>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 93);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            TeacherProjectManager v = new TeacherProjectManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 93;
                v.ProjectId = AddProject();
                v.TeacherId = AddTeacher();
                context.Set<TeacherProjectManager>().Add(v);
                context.SaveChanges();
            }

            TeacherProjectManagerVM vm = _controller.Wtm.CreateVM<TeacherProjectManagerVM>();
            var oldID = v.ID;
            v = new TeacherProjectManager();
            v.ID = oldID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.ProjectId", "");
            vm.FC.Add("Entity.TeacherId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TeacherProjectManager>().Find(v.ID);
 				
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            TeacherProjectManager v = new TeacherProjectManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 93;
                v.ProjectId = AddProject();
                v.TeacherId = AddTeacher();
                context.Set<TeacherProjectManager>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            TeacherProjectManager v1 = new TeacherProjectManager();
            TeacherProjectManager v2 = new TeacherProjectManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 93;
                v1.ProjectId = AddProject();
                v1.TeacherId = AddTeacher();
                v2.ID = 10;
                v2.ProjectId = v1.ProjectId; 
                v2.TeacherId = v1.TeacherId; 
                context.Set<TeacherProjectManager>().Add(v1);
                context.Set<TeacherProjectManager>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<TeacherProjectManager>().Find(v1.ID);
                var data2 = context.Set<TeacherProjectManager>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Int32 AddProject()
        {
            ProjectInfo v = new ProjectInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 89;
                v.Code = "aiQjwIb6E";
                v.Name = "CwfbzpRNP";
                v.TypeOfProject = SchoolManager.Model.BasicInfo.TypeOfProjectEnum.Teacher;
                context.Set<ProjectInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddPosition()
        {
            PositionInfo v = new PositionInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 54;
                v.Code = "TYzEgOYO";
                v.Name = "6M4hqLVR";
                context.Set<PositionInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddTitle()
        {
            TitleInfo v = new TitleInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 76;
                v.Code = "fOVuI25";
                v.Name = "BmS";
                context.Set<TitleInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddSchoolInfo()
        {
            SchoolInfo v = new SchoolInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 65;
                v.Code = "FeDi";
                v.Name = "bxd8x";
                v.EnglishName = "AFPFd5K5";
                v.PinyinName = "hEh";
                v.SimplePinyinName = "N9ewiLFme";
                v.SimpleName = "RNqRzpq";
                v.Contacts = "nnL";
                v.Phone = "Xo3UI";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.CDJY;
                v.Address = "wGssKDe8";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZXJHQ;
                context.Set<SchoolInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddMajorInfo()
        {
            MajorInfo v = new MajorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 73;
                v.Code = "iH8h6npJI";
                v.Name = "7Nq";
                context.Set<MajorInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddPhoto()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.FileName = "OePeh2";
                v.FileExt = "LE0nmBQGN";
                v.Path = "h5q6";
                v.Length = 81;
                v.SaveMode = "fVoWJ2";
                v.ExtraInfo = "VfugwxhJc";
                v.HandlerInfo = "fTGafEOd";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddGrade()
        {
            GradeInfo v = new GradeInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 61;
                v.Code = "7gwX";
                v.Name = "P0eJH9at";
                context.Set<GradeInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddGradeClass()
        {
            GradeClassInfo v = new GradeClassInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 73;
                v.Code = "CILo";
                v.GradeId = AddGrade();
                v.Name = "HGWWra";
                context.Set<GradeClassInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddTeacher()
        {
            TeacherInfo v = new TeacherInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.PositionId = AddPosition();
                v.TitleId = AddTitle();
                v.ID = 22;
                v.Code = "TUQH";
                v.Name = "yXX";
                v.CellPhone = "WaHiE";
                v.ZipCode = "WIPL0eG";
                v.EmContacts = "zhT6";
                v.EmConPhone = "UraFjP";
                v.SchoolInfoId = AddSchoolInfo();
                v.MajorInfoId = AddMajorInfo();
                v.PhotoId = AddPhoto();
                v.GradeClassId = AddGradeClass();
                context.Set<TeacherInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
