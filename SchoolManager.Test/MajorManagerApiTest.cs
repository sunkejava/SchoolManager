using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Common.MajorManagerVMs;
using SchoolManager.Model.MajorMiddleInfo;
using SchoolManager.DataAccess;
using SchoolManager.Model.BasicInfo;
using SchoolManager.Model.Business;


namespace SchoolManager.Test
{
    [TestClass]
    public class MajorManagerApiTest
    {
        private MajorManagerController _controller;
        private string _seed;

        public MajorManagerApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<MajorManagerController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new MajorManagerSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            MajorManagerVM vm = _controller.Wtm.CreateVM<MajorManagerVM>();
            MajorManager v = new MajorManager();
            
            v.ID = 29;
            v.HonorId = AddHonor();
            v.StudentId = AddStudent();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<MajorManager>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 29);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            MajorManager v = new MajorManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 29;
                v.HonorId = AddHonor();
                v.StudentId = AddStudent();
                context.Set<MajorManager>().Add(v);
                context.SaveChanges();
            }

            MajorManagerVM vm = _controller.Wtm.CreateVM<MajorManagerVM>();
            var oldID = v.ID;
            v = new MajorManager();
            v.ID = oldID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.HonorId", "");
            vm.FC.Add("Entity.StudentId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<MajorManager>().Find(v.ID);
 				
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            MajorManager v = new MajorManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 29;
                v.HonorId = AddHonor();
                v.StudentId = AddStudent();
                context.Set<MajorManager>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            MajorManager v1 = new MajorManager();
            MajorManager v2 = new MajorManager();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 29;
                v1.HonorId = AddHonor();
                v1.StudentId = AddStudent();
                v2.ID = 7;
                v2.HonorId = v1.HonorId; 
                v2.StudentId = v1.StudentId; 
                context.Set<MajorManager>().Add(v1);
                context.Set<MajorManager>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<MajorManager>().Find(v1.ID);
                var data2 = context.Set<MajorManager>().Find(v2.ID);
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

                v.ID = 35;
                v.Code = "dy7p3Rs2";
                v.Name = "V4fHBkvwp";
                v.TypeOfHonor = SchoolManager.Model.BasicInfo.TypeOfHonorEnum.Teacher;
                context.Set<HonorInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddSchoolInfo()
        {
            SchoolInfo v = new SchoolInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 5;
                v.Code = "cBZXYIY";
                v.Name = "1hieZc";
                v.EnglishName = "GYS3Os";
                v.PinyinName = "zq4Q";
                v.SimplePinyinName = "4oV4OOnR";
                v.SimpleName = "rBAg";
                v.Contacts = "opD93EQ";
                v.Phone = "ZVLs67si";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.XQJY;
                v.Address = "vxj4t";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.XZXQ;
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

                v.ID = 52;
                v.Code = "kkKiR";
                v.Name = "Z57P";
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

                v.FileName = "dCrMG";
                v.FileExt = "SPrtfG";
                v.Path = "sS5sJDR";
                v.Length = 15;
                v.SaveMode = "aAog6";
                v.ExtraInfo = "NZHZqs";
                v.HandlerInfo = "4AoJ0C";
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

                v.ID = 37;
                v.Code = "KQQwkEYd";
                v.Name = "fTCyrbRy";
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

                v.ID = 29;
                v.Code = "9SR4";
                v.GradeId = AddGrade();
                v.Name = "bmriQQv";
                context.Set<GradeClassInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Int32 AddStudent()
        {
            StudentInfo v = new StudentInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 13;
                v.Code = "fJ03Fa";
                v.Name = "zJvGQT";
                v.CellPhone = "17eWh4d";
                v.ZipCode = "Ija1QJRI";
                v.EmContacts = "eThd79Q3";
                v.EmConPhone = "aYomEcLa";
                v.SchoolInfoId = AddSchoolInfo();
                v.MajorInfoId = AddMajorInfo();
                v.PhotoId = AddPhoto();
                v.GradeClassId = AddGradeClass();
                context.Set<StudentInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
