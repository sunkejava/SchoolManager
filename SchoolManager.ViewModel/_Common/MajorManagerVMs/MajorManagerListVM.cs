using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.MajorMiddleInfo;
using SchoolManager.Model.BasicInfo;
using SchoolManager.Model.Business;


namespace SchoolManager.ViewModel._Common.MajorManagerVMs
{
    public partial class MajorManagerListVM : BasePagedListVM<MajorManager_View, MajorManagerSearcher>
    {

        protected override IEnumerable<IGridColumn<MajorManager_View>> InitGridHeader()
        {
            return new List<GridColumn<MajorManager_View>>{
                this.MakeGridHeader(x => x.StartDate),
                this.MakeGridHeader(x => x.EndDate),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<MajorManager_View> GetSearchQuery()
        {
            var query = DC.Set<MajorManager>()
                .CheckBetween(Searcher.StartDate?.GetStartTime(), Searcher.StartDate?.GetEndTime(), x => x.StartDate, includeMax: false)
                .CheckBetween(Searcher.EndDate?.GetStartTime(), Searcher.EndDate?.GetEndTime(), x => x.EndDate, includeMax: false)
                .CheckEqual(Searcher.HonorId, x=>x.HonorId)
                .CheckEqual(Searcher.StudentId, x=>x.StudentId)
                .Select(x => new MajorManager_View
                {
				    ID = x.ID,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Name_view = x.Honor.Name,
                    Name_view2 = x.Student.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class MajorManager_View : MajorManager{
        [Display(Name = "Column.Name")]
        public String Name_view { get; set; }
        [Display(Name = "Column.Name")]
        public String Name_view2 { get; set; }

    }
}
