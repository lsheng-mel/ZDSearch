using System.Linq;
using AutoMapper;
using ZendeskSearch.Model;

namespace ZendeskSearch.SearchResult.Mapping
{
    public class ZendeskSearchResultMappingProfile : Profile
    {
        public ZendeskSearchResultMappingProfile()
        {
            // user -> UserView
            CreateMap<User, UserView>()
                .ForMember(dst => dst.organization_name, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                        ((Organization) (((Zendesk) context.Options.Items["dataset"]).Data[nameof(Organization)]
                            .FirstOrDefault(o => ((Organization) o)._Id == src.Organization_id)))?.Name
                ))
                .ForMember(dst => dst.submitted_tickets, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                        ((Zendesk) context.Options.Items["dataset"]).Data[nameof(Ticket)]
                        .Where(t => ((Ticket) t).Submitter_id == src._Id)
                        .Select(t => ((Ticket) t).Subject)
                        .ToList()
                ));

            // Ticket -> TicketView
            CreateMap<Ticket, TicketView>()
                .ForMember(dst => dst.organization_name, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                        ((Organization) (((Zendesk) context.Options.Items["dataset"]).Data[nameof(Organization)]
                            .FirstOrDefault(o => ((Organization) o)._Id == src.Organization_id)))?.Name
                ))
                .ForMember(dst => dst.submitter, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                        ((User) (((Zendesk) context.Options.Items["dataset"]).Data[nameof(User)]
                            .FirstOrDefault(o => ((User) o)._Id == src.Submitter_id)))?.Name
                ))
                .ForMember(dst => dst.assignee, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                        ((User) (((Zendesk) context.Options.Items["dataset"]).Data[nameof(User)]
                            .FirstOrDefault(o => ((User) o)._Id == src.Assignee_id)))?.Name
                ));
            
            // Organization -> OrganizationView
            CreateMap<Organization, OrganizationView>()
                .ForMember(dst => dst.users, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                        ((Zendesk) context.Options.Items["dataset"]).Data[nameof(User)]
                        .Where(t => ((User) t).Organization_id == src._Id)
                        .Select(t => ((User) t).Name)
                ))
                .ForMember(dst => dst.tickets, opt => opt.MapFrom(
                    (src, dst, _, context) =>
                        ((Zendesk) context.Options.Items["dataset"]).Data[nameof(Ticket)]
                        .Where(t => ((Ticket) t).Organization_id == src._Id)
                        .Select(t => ((Ticket) t).Subject)
                ));
        }
    }
}