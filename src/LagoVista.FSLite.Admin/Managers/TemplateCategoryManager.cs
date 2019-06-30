using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Managers
{
    public class TemplateCategoryManager : ManagerBase, ITemplateCategoryManager
    {
        ITemplateCategoryRep _repo;
        public TemplateCategoryManager(ITemplateCategoryRep repo, IAppConfig appConfig, IAdminLogger logger,
                                   IDependencyManager depmanager, ISecurity security)
            : base(logger, appConfig, depmanager, security)
        {
            _repo = repo; ;
        }

        public async Task<InvokeResult> AddTemplateCategoryAsync(TemplateCategory templateCategory, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(templateCategory, Actions.Create);

            await AuthorizeAsync(templateCategory, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddTemplateCateogrydAsync(templateCategory);

            return InvokeResult.Success;
        }

        public async Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var templateCategory = await _repo.GetTemplateCategoryAsync(id);
            await AuthorizeAsync(templateCategory, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(templateCategory);
        }

        public async Task<InvokeResult> DeleteTemplateCateogryAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetTemplateCategoryAsync(id);
            await ConfirmNoDepenenciesAsync(board);

            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeleteTemplateCateogryAsync(id);

            return InvokeResult.Success;
        }

        public async Task<ListResponse<TemplateCategorySummary>> GetTemplateCategoriesAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(TemplateCategory));
            return await _repo.GetTemplateCategoriesForOrgAsync(org.Id, listRequest);
        }

        public async Task<TemplateCategory> GetTemplateCategoryAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetTemplateCategoryAsync(id);
            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.Read, user, org);

            return board;
        }

        public Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            return _repo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<InvokeResult> UpdateTemplateCategoryAsync(TemplateCategory templateCategory, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(templateCategory, AuthorizeResult.AuthorizeActions.Update, user, org);

            Validator.Validate(templateCategory, Actions.Update);

            await _repo.UpdateTemplateCateogryAsync(templateCategory);

            return InvokeResult.Success;
        }
    }
}
