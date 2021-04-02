using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.GradeClassInfoVMs
{
    public partial class GradeClassInfoListVM : BasePagedListVM<GradeClassInfo_View, GradeClassInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<GradeClassInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<GradeClassInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<GradeClassInfo_View> GetSearchQuery()
        {
            var query = DC.Set<GradeClassInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckEqual(Searcher.GradeId, x=>x.GradeId)
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new GradeClassInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name_view = x.Grade.Name,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class GradeClassInfo_View : GradeClassInfo{
        [Display(Name = "Column.Name")]
        public String Name_view { get; set; }

    }
}
