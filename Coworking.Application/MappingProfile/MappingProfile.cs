using AutoMapper;
using Coworking.Domain.Entities;
using Coworking.Application.DTOs;

namespace CoworkingSpaceBookingAPI.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User DTO
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Role));

            // UserRole DTO
            CreateMap<UserRoleDto, UserRole>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            CreateMap<UserRole, UserRoleDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            // WorkspaceType DTO
            CreateMap<WorkspaceTypeDto, WorkspaceType>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<WorkspaceType, WorkspaceTypeDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            // Workspace DTO
            CreateMap<WorkspaceDto, Workspace>()
                .ForMember(dest => dest.HasSocket, opt => opt.MapFrom(src => src.HasSocket))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.WorkspaceTypeId, opt => opt.MapFrom(src => src.WorkspaceTypeId));

            CreateMap<Workspace, WorkspaceDto>()
                .ForMember(dest => dest.HasSocket, opt => opt.MapFrom(src => src.HasSocket))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.WorkspaceTypeId, opt => opt.MapFrom(src => src.WorkspaceTypeId));

            // Room Dto
            CreateMap<RoomDto, Room>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor));

            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor));

            // Booking Dto
            CreateMap<BookingDto, Booking>()
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
             .ForMember(dest => dest.WorkspaceId, opt => opt.MapFrom(src => src.WorkspaceId))
             .ForMember(dest => dest.ReservationStartTime, opt => opt.MapFrom(src => src.ReservationStartTime))
             .ForMember(dest => dest.ReservationDurationMinutes, opt => opt.MapFrom(src => src.ReservationDurationMinutes))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.WorkspaceId, opt => opt.MapFrom(src => src.WorkspaceId))
                .ForMember(dest => dest.ReservationStartTime, opt => opt.MapFrom(src => src.ReservationStartTime))
                .ForMember(dest => dest.ReservationDurationMinutes, opt => opt.MapFrom(src => src.ReservationDurationMinutes))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
