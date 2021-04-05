using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Common.TeacherMajorManagerVMs;
using SchoolManager.Model.Business;
using SchoolManager.DataAccess;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.Test
{
    [TestClass]
    public class TeacherMajorManagerApiTest
    {
        private TeacherMajorManagerController _controller;
        private string _seed;

        public TeacherMajorManagerApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<TeacherMajorManagerController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new TeacherMajorManagerSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            TeacherMajorManagerVM vm = _controller.Wtm.CreateVM<TeacherMajorManagerVM>();
            TeacherMajorManager v = new TeacherMajorManager();
            
            v.ID = 72;
            v.HonorId = AddHonor();
            v.TeacherId = AddTeacher();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TeacherMajorManager>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 72);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            TeacherMajorManager v = new TeacherMajorManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 72;
                v.HonorId = AddHonor();
                v.TeacherId = AddTeacher();
                context.Set<TeacherMajorManager>().Add(v);
                context.SaveChanges();
            }

            TeacherMajorManagerVM vm = _controller.Wtm.CreateVM<TeacherMajorManagerVM>();
            var oldID = v.ID;
            v = new TeacherMajorManager();
            v.ID = oldID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.HonorId", "");
            vm.FC.Add("Entity.TeacherId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TeacherMajorManager>().Find(v.ID);
 				
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            TeacherMajorManager v = new TeacherMajorManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 72;
                v.HonorId = AddHonor();
                v.TeacherId = AddTeacher();
                context.Set<TeacherMajorManager>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            TeacherMajorManager v1 = new TeacherMajorManager();
            TeacherMajorManager v2 = new TeacherMajorManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 72;
                v1.HonorId = AddHonor();
                v1.TeacherId = AddTeacher();
                v2.ID = 6;
                v2.HonorId = v1.HonorId; 
                v2.TeacherId = v1.TeacherId; 
                context.Set<TeacherMajorManager>().Add(v1);
                context.Set<TeacherMajorManager>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<TeacherMajorManager>().Find(v1.ID);
                var data2 = context.Set<TeacherMajorManager>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Int32 AddHonor()
        {
            HonorInfo v = new HonorInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 41;
                v.Code = "GWRkkzfM";
                v.Name = "xM04L8";
                v.TypeOfHonor = SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Teacher;
                context.Set<HonorInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddPosition()
        {
            PositionInfo v = new PositionInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 87;
                v.Code = "eOGD";
                v.Name = "CDH9k";
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

                v.ID = 50;
                v.Code = "E3KZD";
                v.Name = "6M3";
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

                v.ID = 30;
                v.Code = "HF33";
                v.Name = "z8o";
                v.EnglishName = "A61kjlvI";
                v.PinyinName = "bK4TFnct";
                v.SimplePinyinName = "WqB";
                v.SimpleName = "GUkNLqvm";
                v.Contacts = "j4F25sq";
                v.Phone = "Kuw";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.ZDJY;
                v.Address = "wkLkmgK";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.TSQY;
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

                v.ID = 28;
                v.Code = "rve9";
                v.Name = "TqEqQ";
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

                v.FileName = "5U9XZ";
                v.FileExt = "z2a";
                v.Path = "hyh8N5i9";
                v.Length = 99;
                v.SaveMode = "ermwCvQyX";
                v.ExtraInfo = "30O";
                v.HandlerInfo = "eDCLVl17P";
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

                v.ID = 81;
                v.Code = "hmOZnHcl";
                v.Name = "qgdULr";
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

                v.ID = 72;
                v.Code = "R1i6hPI";
                v.GradeId = AddGrade();
                v.Name = "fhS";
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
                v.ID = 61;
                v.Code = "327yEO";
                v.Name = "MiKcz";
                v.CellPhone = "iXJ";
                v.ZipCode = "YleY";
                v.EmContacts = "1kUkaHW";
                v.EmConPhone = "Ve9N5ymDT";
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
