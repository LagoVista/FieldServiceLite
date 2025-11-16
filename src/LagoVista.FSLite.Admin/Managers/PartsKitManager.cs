// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: c2ca72bbc55dcb6022d0625b2337e9beea55de40fc49cac6d862064075d08edc
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Managers
{
    public class PartsKitManager : ManagerBase, IPartsKitManager
    {
        IPartsKitRepo _repo;
        public PartsKitManager(IPartsKitRepo repo, IAppConfig appConfig, IAdminLogger logger,
                           IDependencyManager depmanager, ISecurity security) : base(logger, appConfig, depmanager, security)
        {
            _repo = repo; ;
        }

        public async Task<InvokeResult> AddPartsKitAsync(PartsKit partsKit, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(partsKit, Actions.Create);

            await AuthorizeAsync(partsKit, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddPartsKitAsync(partsKit);

            return InvokeResult.Success;
        }

        public async Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetPartsKitAsync(id);
            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(board);
        }

        public async Task<InvokeResult> DeletePartsKitAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetPartsKitAsync(id);
            await ConfirmNoDepenenciesAsync(board);

            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeletePartsKitAsync(id);

            return InvokeResult.Success;
        }

        public async Task<PartsKit> GetPartsKitAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetPartsKitAsync(id);
            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.GetForOrgs, user, org);

            return board;
        }

        public async Task<ListResponse<PartsKitSummary>> GetPartsKitsAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(PartsKit));
            return await _repo.GetPartsKitsForOrgAsync(org.Id, listRequest);
        }

        public Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            return _repo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<InvokeResult> UpdatePartsKitAsync(PartsKit partsKit, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(partsKit, AuthorizeResult.AuthorizeActions.Update, user, org);
            Validator.Validate(partsKit, Actions.Update);

            await _repo.UpdatePartsKitAsync(partsKit);

            return InvokeResult.Success;
        }
    }
}
