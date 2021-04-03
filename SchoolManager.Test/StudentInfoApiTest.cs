using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Business.StudentInfoVMs;
using SchoolManager.Model.Business;
using SchoolManager.DataAccess;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.Test
{
    [TestClass]
    public class StudentInfoApiTest
    {
        private StudentInfoController _controller;
        private string _seed;

        public StudentInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<StudentInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new StudentInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            StudentInfoVM vm = _controller.Wtm.CreateVM<StudentInfoVM>();
            StudentInfo v = new StudentInfo();
            
            v.ID = 6;
            v.Code = "Uz98";
            v.Name = "NyYozvFB";
            v.CellPhone = "RrngOzdfE";
            v.ZipCode = "JmAE";
            v.EmContacts = "WPYPQa";
            v.EmConPhone = "4hXF";
            v.SchoolInfoId = AddSchoolInfo();
            v.MajorInfoId = AddMajorInfo();
            v.PhotoId = AddPhoto();
            v.GradeClassId = AddGradeClass();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 6);
                Assert.AreEqual(data.Code, "Uz98");
                Assert.AreEqual(data.Name, "NyYozvFB");
                Assert.AreEqual(data.CellPhone, "RrngOzdfE");
                Assert.AreEqual(data.ZipCode, "JmAE");
                Assert.AreEqual(data.EmContacts, "WPYPQa");
                Assert.AreEqual(data.EmConPhone, "4hXF");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            StudentInfo v = new StudentInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 6;
                v.Code = "Uz98";
                v.Name = "NyYozvFB";
                v.CellPhone = "RrngOzdfE";
                v.ZipCode = "JmAE";
                v.EmContacts = "WPYPQa";
                v.EmConPhone = "4hXF";
                v.SchoolInfoId = AddSchoolInfo();
                v.MajorInfoId = AddMajorInfo();
                v.PhotoId = AddPhoto();
                v.GradeClassId = AddGradeClass();
                context.Set<StudentInfo>().Add(v);
                context.SaveChanges();
            }

            StudentInfoVM vm = _controller.Wtm.CreateVM<StudentInfoVM>();
            var oldID = v.ID;
            v = new StudentInfo();
            v.ID = oldID;
       		
            v.Code = "pGvsLp";
            v.Name = "KU1Oe0";
            v.CellPhone = "FQm4wobP";
            v.ZipCode = "rm78fj";
            v.EmContacts = "7Xi9d3M";
            v.EmConPhone = "QOi";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Code", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.CellPhone", "");
            vm.FC.Add("Entity.ZipCode", "");
            vm.FC.Add("Entity.EmContacts", "");
            vm.FC.Add("Entity.EmConPhone", "");
            vm.FC.Add("Entity.SchoolInfoId", "");
            vm.FC.Add("Entity.MajorInfoId", "");
            vm.FC.Add("Entity.PhotoId", "");
            vm.FC.Add("Entity.GradeClassId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "pGvsLp");
                Assert.AreEqual(data.Name, "KU1Oe0");
                Assert.AreEqual(data.CellPhone, "FQm4wobP");
                Assert.AreEqual(data.ZipCode, "rm78fj");
                Assert.AreEqual(data.EmContacts, "7Xi9d3M");
                Assert.AreEqual(data.EmConPhone, "QOi");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            StudentInfo v = new StudentInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 6;
                v.Code = "Uz98";
                v.Name = "NyYozvFB";
                v.CellPhone = "RrngOzdfE";
                v.ZipCode = "JmAE";
                v.EmContacts = "WPYPQa";
                v.EmConPhone = "4hXF";
                v.SchoolInfoId = AddSchoolInfo();
                v.MajorInfoId = AddMajorInfo();
                v.PhotoId = AddPhoto();
                v.GradeClassId = AddGradeClass();
                context.Set<StudentInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            StudentInfo v1 = new StudentInfo();
            StudentInfo v2 = new StudentInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 6;
                v1.Code = "Uz98";
                v1.Name = "NyYozvFB";
                v1.CellPhone = "RrngOzdfE";
                v1.ZipCode = "JmAE";
                v1.EmContacts = "WPYPQa";
                v1.EmConPhone = "4hXF";
                v1.SchoolInfoId = AddSchoolInfo();
                v1.MajorInfoId = AddMajorInfo();
                v1.PhotoId = AddPhoto();
                v1.GradeClassId = AddGradeClass();
                v2.ID = 31;
                v2.Code = "pGvsLp";
                v2.Name = "KU1Oe0";
                v2.CellPhone = "FQm4wobP";
                v2.ZipCode = "rm78fj";
                v2.EmContacts = "7Xi9d3M";
                v2.EmConPhone = "QOi";
                v2.SchoolInfoId = v1.SchoolInfoId; 
                v2.MajorInfoId = v1.MajorInfoId; 
                v2.PhotoId = v1.PhotoId; 
                v2.GradeClassId = v1.GradeClassId; 
                context.Set<StudentInfo>().Add(v1);
                context.Set<StudentInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<StudentInfo>().Find(v1.ID);
                var data2 = context.Set<StudentInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Int32 AddSchoolInfo()
        {
            SchoolInfo v = new SchoolInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 69;
                v.Code = "SS8YYt8";
                v.Name = "rRLu8WOtN";
                v.EnglishName = "cgEtb";
                v.PinyinName = "Cjp";
                v.SimplePinyinName = "TCAM";
                v.SimpleName = "A17H1N48";
                v.Contacts = "mWAILbby";
                v.Phone = "nHf6sXodt";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.GDJY;
                v.Address = "n81";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.CZ;
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

                v.ID = 60;
                v.Code = "d466y";
                v.Name = "ycF3x7S7U";
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

                v.FileName = "Dc8";
                v.FileExt = "gxnxHB";
                v.Path = "0iJHf4t";
                v.Length = 66;
                v.SaveMode = "Ssx6XyKDR";
                v.ExtraInfo = "FcI95";
                v.HandlerInfo = "aW4";
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

                v.ID = 28;
                v.Code = "EChih94AO";
                v.Name = "HXzu9rH";
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

                v.ID = 46;
                v.Code = "BZx5KG";
                v.GradeId = AddGrade();
                v.Name = "T7voVUdM";
                context.Set<GradeClassInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
