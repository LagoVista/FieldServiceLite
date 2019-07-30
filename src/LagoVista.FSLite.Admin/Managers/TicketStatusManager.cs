using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin
{
    public class TicketStatusManager : ManagerBase, ITicketStatusManager
    {

        ITicketStatusRepo _repo;
        public TicketStatusManager(ITicketStatusRepo repo, IAppConfig appConfig, IAdminLogger logger,
                           IDependencyManager depmanager, ISecurity security) : base(logger, appConfig, depmanager, security)
        {
            _repo = repo;
        }

        public async Task<InvokeResult> AddTicketStatusItemsAsync(TicketStatusItems ticketStatusItems, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(ticketStatusItems, Actions.Create);

            await AuthorizeAsync(ticketStatusItems, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddTicketStatusItemsAsync(ticketStatusItems);

            return InvokeResult.Success;
        }

        public async Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var ticketStatusItems = await _repo.GetTicketStatusItemsAsync(id);
            await AuthorizeAsync(ticketStatusItems, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(ticketStatusItems);
        }

        public async Task<InvokeResult> DeleteTicketStatusItemsAsync(string id, EntityHeader org, EntityHeader user)
        {
            var tickeStatusItems = await _repo.GetTicketStatusItemsAsync(id);
            await ConfirmNoDepenenciesAsync(tickeStatusItems);

            await AuthorizeAsync(tickeStatusItems, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeleteTicketStatusItemsAsync(id);

            return InvokeResult.Success;
        }

        public async Task<TicketStatusItems> GetTicketStatusItemsAsync(string id, EntityHeader org, EntityHeader user)
        {
            var board = await _repo.GetTicketStatusItemsAsync(id);
            await AuthorizeAsync(board, AuthorizeResult.AuthorizeActions.GetForOrgs, user, org);

            return board;
        }

        public async Task<ListResponse<TicketStatusItemsSummary>> GetTicketStatusItemsAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(PartsKit));
            return await _repo.GetTicketStatusForOrgAsync(org.Id, listRequest);
        }

        public Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            return _repo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<InvokeResult> UpdateTicketStatusItemsAsync(TicketStatusItems ticketStatusItems, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(ticketStatusItems, AuthorizeResult.AuthorizeActions.Update, user, org);
            Validator.Validate(ticketStatusItems, Actions.Update);

            await _repo.UpdateTicketStatusItemsAsync(ticketStatusItems);

            return InvokeResult.Success;
        }
    }
}
