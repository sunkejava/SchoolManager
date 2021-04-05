using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;


namespace SchoolManager.ViewModel._Common.TeacherProjectManagerVMs
{
    public partial class TeacherProjectManagerBatchVM : BaseBatchVM<TeacherProjectManager, TeacherProjectManager_BatchEdit>
    {
        public TeacherProjectManagerBatchVM()
        {
            ListVM = new TeacherProjectManagerListVM();
            LinkedVM = new TeacherProjectManager_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class TeacherProjectManager_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
