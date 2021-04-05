using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using SchoolManager.ViewModel._Common.TeacherInfoVMs;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.Controllers
{
    [Area("_Common")]
    [AuthorizeJwtWithCookie]
    [ActionDescription("教师信息")]
    [ApiController]
    [Route("api/TeacherInfo")]
	public partial class TeacherInfoController : BaseApiController
    {
        [ActionDescription("Sys.Search")]
        [HttpPost("Search")]
		public IActionResult Search(TeacherInfoSearcher searcher)
        {
            if (ModelState.IsValid)
            {
                var vm = Wtm.CreateVM<TeacherInfoListVM>();
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
        public TeacherInfoVM Get(string id)
        {
            var vm = Wtm.CreateVM<TeacherInfoVM>(id);
            return vm;
        }

        [ActionDescription("Sys.Create")]
        [HttpPost("Add")]
        public IActionResult Add(TeacherInfoVM vm)
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
        public IActionResult Edit(TeacherInfoVM vm)
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
            var vm = Wtm.CreateVM<TeacherInfoBatchVM>();
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
        public IActionResult ExportExcel(TeacherInfoSearcher searcher)
        {
            var vm = Wtm.CreateVM<TeacherInfoListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            return vm.GetExportData();
        }

        [ActionDescription("Sys.CheckExport")]
        [HttpPost("ExportExcelByIds")]
        public IActionResult ExportExcelByIds(string[] ids)
        {
            var vm = Wtm.CreateVM<TeacherInfoListVM>();
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
            var vm = Wtm.CreateVM<TeacherInfoImportVM>();
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
        public ActionResult Import(TeacherInfoImportVM vm)
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


        [HttpGet("GetPositionInfos")]
        public ActionResult GetPositionInfos()
        {
            return Ok(DC.Set<PositionInfo>().GetSelectListItems(Wtm, x => x.Name));
        }

        [HttpGet("GetTitleInfos")]
        public ActionResult GetTitleInfos()
        {
            return Ok(DC.Set<TitleInfo>().GetSelectListItems(Wtm, x => x.Name));
        }

        [HttpGet("GetProjectInfos")]
        public ActionResult GetProjectInfos()
        {
            return Ok(DC.Set<ProjectInfo>().GetSelectListItems(Wtm, x => x.Name));
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
