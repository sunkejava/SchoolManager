using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Common.TeacherInfoVMs
{
    public partial class TeacherInfoListVM : BasePagedListVM<TeacherInfo_View, TeacherInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<TeacherInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<TeacherInfo_View>>{
                this.MakeGridHeader(x => x.InTake),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.Name_view3),
                this.MakeGridHeader(x => x.Name_view4),
                this.MakeGridHeader(x => x.Name_view5),
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.CellPhone),
                this.MakeGridHeader(x => x.ZipCode),
                this.MakeGridHeader(x => x.EmContacts),
                this.MakeGridHeader(x => x.EmConPhone),
                this.MakeGridHeader(x => x.EnglishName_view),
                this.MakeGridHeader(x => x.Name_view6),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeader(x => x.Name_view7),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(TeacherInfo_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<TeacherInfo_View> GetSearchQuery()
        {
            var query = DC.Set<TeacherInfo>()
                .CheckBetween(Searcher.InTake?.GetStartTime(), Searcher.InTake?.GetEndTime(), x => x.InTake, includeMax: false)
                .CheckEqual(Searcher.PositionId, x=>x.PositionId)
                .CheckEqual(Searcher.TitleId, x=>x.TitleId)
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.CellPhone, x=>x.CellPhone)
                .CheckContain(Searcher.ZipCode, x=>x.ZipCode)
                .CheckContain(Searcher.EmContacts, x=>x.EmContacts)
                .CheckContain(Searcher.EmConPhone, x=>x.EmConPhone)
                .CheckEqual(Searcher.SchoolInfoId, x=>x.SchoolInfoId)
                .CheckEqual(Searcher.MajorInfoId, x=>x.MajorInfoId)
                .CheckEqual(Searcher.GradeClassId, x=>x.GradeClassId)
                .Select(x => new TeacherInfo_View
                {
				    ID = x.ID,
                    InTake = x.InTake,
                    Name_view = x.Position.Name,
                    Name_view2 = x.Title.Name,
                    Name_view3 = x.TeacherProjects.Where(y=>y.Project.IsValid==true).Select(y=>y.Project.Name).ToSepratedString(null,","), 
                    Name_view4 = x.StudentHonors.Where(y=>y.Honor.IsValid==true).Select(y=>y.Honor.Name).ToSepratedString(null,","), 
                    Name_view5 = x.StudentSubjects.Where(y=>y.Subject.IsValid==true).Select(y=>y.Subject.Name).ToSepratedString(null,","), 
                    Code = x.Code,
                    Name = x.Name,
                    CellPhone = x.CellPhone,
                    ZipCode = x.ZipCode,
                    EmContacts = x.EmContacts,
                    EmConPhone = x.EmConPhone,
                    EnglishName_view = x.SchoolInfo.EnglishName,
                    Name_view6 = x.MajorInfo.Name,
                    PhotoId = x.PhotoId,
                    Name_view7 = x.GradeClass.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class TeacherInfo_View : TeacherInfo{
        [Display(Name = "Column.Name")]
        public String Name_view { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view2 { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view3 { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view4 { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view5 { get; set; }
        [Display(Name = "Column.EnglishName")]
        public String EnglishName_view { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view6 { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view7 { get; set; }

    }
}
