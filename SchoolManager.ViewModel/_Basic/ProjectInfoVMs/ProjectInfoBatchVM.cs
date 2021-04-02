using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.ProjectInfoVMs
{
    public partial class ProjectInfoBatchVM : BaseBatchVM<ProjectInfo, ProjectInfo_BatchEdit>
    {
        public ProjectInfoBatchVM()
        {
            ListVM = new ProjectInfoListVM();
            LinkedVM = new ProjectInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ProjectInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
