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


namespace SchoolManager.ViewModel._Common.TeacherProjectManagerVMs
{
    public partial class TeacherProjectManagerListVM : BasePagedListVM<TeacherProjectManager_View, TeacherProjectManagerSearcher>
    {

        protected override IEnumerable<IGridColumn<TeacherProjectManager_View>> InitGridHeader()
        {
            return new List<GridColumn<TeacherProjectManager_View>>{
                this.MakeGridHeader(x => x.StartDate),
                this.MakeGridHeader(x => x.EndDate),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<TeacherProjectManager_View> GetSearchQuery()
        {
            var query = DC.Set<TeacherProjectManager>()
                .CheckBetween(Searcher.StartDate?.GetStartTime(), Searcher.StartDate?.GetEndTime(), x => x.StartDate, includeMax: false)
                .CheckBetween(Searcher.EndDate?.GetStartTime(), Searcher.EndDate?.GetEndTime(), x => x.EndDate, includeMax: false)
                .CheckEqual(Searcher.ProjectId, x=>x.ProjectId)
                .CheckEqual(Searcher.TeacherId, x=>x.TeacherId)
                .Select(x => new TeacherProjectManager_View
                {
				    ID = x.ID,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Name_view = x.Project.Name,
                    Name_view2 = x.Teacher.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class TeacherProjectManager_View : TeacherProjectManager{
        [Display(Name = "Column.Name")]
        public String Name_view { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view2 { get; set; }

    }
}
