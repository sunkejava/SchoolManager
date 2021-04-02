using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.ProjectInfoVMs
{
    public partial class ProjectInfoListVM : BasePagedListVM<ProjectInfo_View, ProjectInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<ProjectInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<ProjectInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ProjectInfo_View> GetSearchQuery()
        {
            var query = DC.Set<ProjectInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new ProjectInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ProjectInfo_View : ProjectInfo{

    }
}
