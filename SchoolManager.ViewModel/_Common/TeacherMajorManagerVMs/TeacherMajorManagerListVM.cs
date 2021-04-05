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


namespace SchoolManager.ViewModel._Common.TeacherMajorManagerVMs
{
    public partial class TeacherMajorManagerListVM : BasePagedListVM<TeacherMajorManager_View, TeacherMajorManagerSearcher>
    {

        protected override IEnumerable<IGridColumn<TeacherMajorManager_View>> InitGridHeader()
        {
            return new List<GridColumn<TeacherMajorManager_View>>{
                this.MakeGridHeader(x => x.StartDate),
                this.MakeGridHeader(x => x.EndDate),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<TeacherMajorManager_View> GetSearchQuery()
        {
            var query = DC.Set<TeacherMajorManager>()
                .CheckBetween(Searcher.StartDate?.GetStartTime(), Searcher.StartDate?.GetEndTime(), x => x.StartDate, includeMax: false)
                .CheckBetween(Searcher.EndDate?.GetStartTime(), Searcher.EndDate?.GetEndTime(), x => x.EndDate, includeMax: false)
                .CheckEqual(Searcher.HonorId, x=>x.HonorId)
                .CheckEqual(Searcher.TeacherId, x=>x.TeacherId)
                .Select(x => new TeacherMajorManager_View
                {
				    ID = x.ID,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Name_view = x.Honor.Name,
                    Name_view2 = x.Teacher.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class TeacherMajorManager_View : TeacherMajorManager{
        [Display(Name = "Column.Name")]
        public String Name_view { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view2 { get; set; }

    }
}
