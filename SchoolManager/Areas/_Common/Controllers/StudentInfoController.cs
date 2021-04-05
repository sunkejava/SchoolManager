using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using SchoolManager.ViewModel._Common.StudentInfoVMs;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.Controllers
{
    [Area("_Common")]
    [AuthorizeJwtWithCookie]
    [ActionDescription("学生管理")]
    [ApiController]
    [Route("api/StudentInfo")]
	public partial class StudentInfoController : BaseApiController
    {
        [ActionDescription("Sys.Search")]
        [HttpPost("Search")]
		public IActionResult Search(StudentInfoSearcher searcher)
        {
            if (ModelState.IsValid)
            {
                var vm = Wtm.CreateVM<StudentInfoListVM>();
                vm.Searcher = searcher;
                return Content(vm.GetJson());
            }
            else
            {
                return BadRequest(ModelState.GetErrorJson());
            }
        }

        [ActionDescription("Sys.Get")]
        [HttpGet("{id}")]
        public StudentInfoVM Get(string id)
        {
            var vm = Wtm.CreateVM<StudentInfoVM>(id);
            return vm;
        }

        [ActionDescription("Sys.Create")]
        [HttpPost("Add")]
        public IActionResult Add(StudentInfoVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }

        }

        [ActionDescription("Sys.Edit")]
        [HttpPut("Edit")]
        public IActionResult Edit(StudentInfoVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                vm.DoEdit(false);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }
        }

		[HttpPost("BatchDelete")]
        [ActionDescription("Sys.Delete")]
        public IActionResult BatchDelete(string[] ids)
        {
            var vm = Wtm.CreateVM<StudentInfoBatchVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = ids;
            }
            else
            {
                return Ok();
            }
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                return Ok(ids.Count());
            }
        }


        [ActionDescription("Sys.Export")]
        [HttpPost("ExportExcel")]
        public IActionResult ExportExcel(StudentInfoSearcher searcher)
        {
            var vm = Wtm.CreateVM<StudentInfoListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            return vm.GetExportData();
        }

        [ActionDescription("Sys.CheckExport")]
        [HttpPost("ExportExcelByIds")]
        public IActionResult ExportExcelByIds(string[] ids)
        {
            var vm = Wtm.CreateVM<StudentInfoListVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = new List<string>(ids);
                vm.SearcherMode = ListVMSearchModeEnum.CheckExport;
            }
            return vm.GetExportData();
        }

        [ActionDescription("Sys.DownloadTemplate")]
        [HttpGet("GetExcelTemplate")]
        public IActionResult GetExcelTemplate()
        {
            var vm = Wtm.CreateVM<StudentInfoImportVM>();
            var qs = new Dictionary<string, string>();
            foreach (var item in Request.Query.Keys)
            {
                qs.Add(item, Request.Query[item]);
            }
            vm.SetParms(qs);
            var data = vm.GenerateTemplate(out string fileName);
            return File(data, "application/vnd.ms-excel", fileName);
        }

        [ActionDescription("Sys.Import")]
        [HttpPost("Import")]
        public ActionResult Import(StudentInfoImportVM vm)
        {

            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return BadRequest(vm.GetErrorJson());
            }
            else
            {
                return Ok(vm.EntityList.Count);
            }
        }


        [HttpGet("GetHonorInfos")]
        public ActionResult GetHonorInfos()
        {
            return Ok(DC.Set<HonorInfo>().GetSelectListItems(Wtm, x => x.Name));
        }

        [HttpGet("GetSubjectInfos")]
        public ActionResult GetSubjectInfos()
        {
            return Ok(DC.Set<SubjectInfo>().GetSelectListItems(Wtm, x => x.Name));
        }

        [HttpGet("GetSchoolInfos")]
        public ActionResult GetSchoolInfos()
        {
            return Ok(DC.Set<SchoolInfo>().GetSelectListItems(Wtm, x => x.EnglishName));
        }

        [HttpGet("GetMajorInfos")]
        public ActionResult GetMajorInfos()
        {
            return Ok(DC.Set<MajorInfo>().GetSelectListItems(Wtm, x => x.Name));
        }

        [HttpGet("GetGradeClassInfos")]
        public ActionResult GetGradeClassInfos()
        {
            return Ok(DC.Set<GradeClassInfo>().GetSelectListItems(Wtm, x => x.Name));
        }

    }
}
