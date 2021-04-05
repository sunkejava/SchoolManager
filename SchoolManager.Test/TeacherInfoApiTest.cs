using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SchoolManager.Controllers;
using SchoolManager.ViewModel._Common.TeacherInfoVMs;
using SchoolManager.Model.Business;
using SchoolManager.DataAccess;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.Test
{
    [TestClass]
    public class TeacherInfoApiTest
    {
        private TeacherInfoController _controller;
        private string _seed;

        public TeacherInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<TeacherInfoController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new TeacherInfoSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            TeacherInfoVM vm = _controller.Wtm.CreateVM<TeacherInfoVM>();
            TeacherInfo v = new TeacherInfo();
            
            v.PositionId = AddPosition();
            v.TitleId = AddTitle();
            v.ID = 12;
            v.Code = "vGZx";
            v.Name = "s1Zly2jQk";
            v.CellPhone = "pcPIG";
            v.ZipCode = "76SBHKce";
            v.EmContacts = "FFIYdZ";
            v.EmConPhone = "ELqcr";
            v.SchoolInfoId = AddSchoolInfo();
            v.MajorInfoId = AddMajorInfo();
            v.PhotoId = AddPhoto();
            v.GradeClassId = AddGradeClass();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TeacherInfo>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 12);
                Assert.AreEqual(data.Code, "vGZx");
                Assert.AreEqual(data.Name, "s1Zly2jQk");
                Assert.AreEqual(data.CellPhone, "pcPIG");
                Assert.AreEqual(data.ZipCode, "76SBHKce");
                Assert.AreEqual(data.EmContacts, "FFIYdZ");
                Assert.AreEqual(data.EmConPhone, "ELqcr");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            TeacherInfo v = new TeacherInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.PositionId = AddPosition();
                v.TitleId = AddTitle();
                v.ID = 12;
                v.Code = "vGZx";
                v.Name = "s1Zly2jQk";
                v.CellPhone = "pcPIG";
                v.ZipCode = "76SBHKce";
                v.EmContacts = "FFIYdZ";
                v.EmConPhone = "ELqcr";
                v.SchoolInfoId = AddSchoolInfo();
                v.MajorInfoId = AddMajorInfo();
                v.PhotoId = AddPhoto();
                v.GradeClassId = AddGradeClass();
                context.Set<TeacherInfo>().Add(v);
                context.SaveChanges();
            }

            TeacherInfoVM vm = _controller.Wtm.CreateVM<TeacherInfoVM>();
            var oldID = v.ID;
            v = new TeacherInfo();
            v.ID = oldID;
       		
            v.Code = "Hxs";
            v.Name = "fVvJIq";
            v.CellPhone = "hkydYmOk6";
            v.ZipCode = "wh2";
            v.EmContacts = "7CV";
            v.EmConPhone = "KZ5J8od";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.PositionId", "");
            vm.FC.Add("Entity.TitleId", "");
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
                var data = context.Set<TeacherInfo>().Find(v.ID);
 				
                Assert.AreEqual(data.Code, "Hxs");
                Assert.AreEqual(data.Name, "fVvJIq");
                Assert.AreEqual(data.CellPhone, "hkydYmOk6");
                Assert.AreEqual(data.ZipCode, "wh2");
                Assert.AreEqual(data.EmContacts, "7CV");
                Assert.AreEqual(data.EmConPhone, "KZ5J8od");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            TeacherInfo v = new TeacherInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.PositionId = AddPosition();
                v.TitleId = AddTitle();
                v.ID = 12;
                v.Code = "vGZx";
                v.Name = "s1Zly2jQk";
                v.CellPhone = "pcPIG";
                v.ZipCode = "76SBHKce";
                v.EmContacts = "FFIYdZ";
                v.EmConPhone = "ELqcr";
                v.SchoolInfoId = AddSchoolInfo();
                v.MajorInfoId = AddMajorInfo();
                v.PhotoId = AddPhoto();
                v.GradeClassId = AddGradeClass();
                context.Set<TeacherInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            TeacherInfo v1 = new TeacherInfo();
            TeacherInfo v2 = new TeacherInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.PositionId = AddPosition();
                v1.TitleId = AddTitle();
                v1.ID = 12;
                v1.Code = "vGZx";
                v1.Name = "s1Zly2jQk";
                v1.CellPhone = "pcPIG";
                v1.ZipCode = "76SBHKce";
                v1.EmContacts = "FFIYdZ";
                v1.EmConPhone = "ELqcr";
                v1.SchoolInfoId = AddSchoolInfo();
                v1.MajorInfoId = AddMajorInfo();
                v1.PhotoId = AddPhoto();
                v1.GradeClassId = AddGradeClass();
                v2.PositionId = v1.PositionId; 
                v2.TitleId = v1.TitleId; 
                v2.ID = 30;
                v2.Code = "Hxs";
                v2.Name = "fVvJIq";
                v2.CellPhone = "hkydYmOk6";
                v2.ZipCode = "wh2";
                v2.EmContacts = "7CV";
                v2.EmConPhone = "KZ5J8od";
                v2.SchoolInfoId = v1.SchoolInfoId; 
                v2.MajorInfoId = v1.MajorInfoId; 
                v2.PhotoId = v1.PhotoId; 
                v2.GradeClassId = v1.GradeClassId; 
                context.Set<TeacherInfo>().Add(v1);
                context.Set<TeacherInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<TeacherInfo>().Find(v1.ID);
                var data2 = context.Set<TeacherInfo>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Int32 AddPosition()
        {
            PositionInfo v = new PositionInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 14;
                v.Code = "Bp0JpCI";
                v.Name = "X7VjBJFw";
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

                v.ID = 20;
                v.Code = "KZzlI";
                v.Name = "xAWoi";
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

                v.ID = 87;
                v.Code = "NEsdleEN";
                v.Name = "GxtgZ";
                v.EnglishName = "OynNhgc";
                v.PinyinName = "iJoC";
                v.SimplePinyinName = "oReuD9f22";
                v.SimpleName = "X4BN3C7Y7";
                v.Contacts = "Ovfsx";
                v.Phone = "YhX";
                v.TypeOfEducation = SchoolManager.Model.BasicInfo.TypeOfEducationEnum.CDJY;
                v.Address = "CqMqE7A";
                v.TypeOfUrbanAndRural = SchoolManager.Model.BasicInfo.TypeOfUrbanAndRuralEnum.ZZXQ;
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

                v.ID = 13;
                v.Code = "Bif";
                v.Name = "wCku2uz";
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

                v.FileName = "4JKe6pp";
                v.FileExt = "oijhUpS7W";
                v.Path = "TfWvTF";
                v.Length = 33;
                v.SaveMode = "JskNYX6";
                v.ExtraInfo = "S2ftNcd";
                v.HandlerInfo = "I8Hq";
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

                v.ID = 92;
                v.Code = "UmZ8IX4xl";
                v.Name = "CF9C";
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

                v.ID = 12;
                v.Code = "nrp9tUWlG";
                v.GradeId = AddGrade();
                v.Name = "OnExyHKDW";
                context.Set<GradeClassInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
