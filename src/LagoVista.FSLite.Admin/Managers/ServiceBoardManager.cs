// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 4535e1c4a9fa8f0194d134ee40f42e1a38f496c4b89e8ec24132b99d2066b07a
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
    public class ServiceBoardManager : ManagerBase, IServiceBoardManager
    {

        IServiceBoardRepo _repo;
        public ServiceBoardManager(IServiceBoardRepo repo, IAppConfig appConfig, IAdminLogger logger,
                                   IDependencyManager depmanager, ISecurity security)
            : base(logger, appConfig, depmanager, security)
        {
            _repo = repo; ;
        }

        public async Task<InvokeResult> AddServiceBoardAsync(ServiceBoard serviceBoard, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(serviceBoard, Actions.Create);

            await AuthorizeAsync(serviceBoard, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddServiceBoardAsync(serviceBoard);

            return InvokeResult.Success;
        }

        public async Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetServiceBoardAsync(id);
            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(board);
        }

        public async Task<InvokeResult> DeleteServiceBoardAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetServiceBoardAsync(id);
            await ConfirmNoDepenenciesAsync(board);

            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeleteServiceBoardAsync(id);

            return InvokeResult.Success;
        }

        public async Task<ServiceBoard> GetServiceBoardAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetServiceBoardAsync(id);
            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.GetForOrgs, user, org);

            return board;
        }

        public async Task<ListResponse<ServiceBoardSummary>> GetServiceBoardsAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicketTemplate));
            return await _repo.GetServiceBoardForOrgAsync(org.Id, listRequest);
        }

        public Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            return _repo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<InvokeResult> UpdateServiceBoardAsync(ServiceBoard serviceBoard, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(serviceBoard, AuthorizeResult.AuthorizeActions.Update, user, org);
            Validator.Validate(serviceBoard, Actions.Update);

            await _repo.UpdateServiceBoardAsync(serviceBoard);

            return InvokeResult.Success;
        }
    }
}
