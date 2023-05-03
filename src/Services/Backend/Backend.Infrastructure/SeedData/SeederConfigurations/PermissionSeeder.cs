using Backend.Domain.Entities;
using Backend.Domain.SeedWork;

namespace Backend.Infrastructure.SeedData.SeederConfigurations;

public class PermissionSeeder
{
    public static void SeedData(BackendDbContext context)
    {
        if (context.Permissions.Any())
            return;

        context.Set<Permission>().AddRange(
            // Manager
            new Permission(Guid.Parse("83e67812-50e1-4a35-939d-362cc77b560a"), "Backend:Users:FullAccess", "Acceso total a los usuarios del backoffice", "USERS", PermissionTypes.Global),
            new Permission(Guid.Parse("c556dfb8-b66a-4393-81cc-864a56381e05"), "Backend:Users:ReadEditAccess", "Acceso de lectura y edición a los usuarios del backoffice", "USERS", PermissionTypes.Global),
            new Permission(Guid.Parse("92a282ec-808c-4a3e-a8fd-a7562aad1c11"), "Backend:Users:ReadOnlyAccess", "Acceso de sólo lectura a los usuarios del backoffice", "USERS", PermissionTypes.Global),
            new Permission(Guid.Parse("79fc0f03-849f-4968-8224-02b6b6f14aa1"), "Backend:Users:Delete", "Acceso eliminar a los usuarios del backoffice", "USERS", PermissionTypes.Global),
            new Permission(Guid.Parse("f737b076-c96b-4863-9be5-13d6808f1b0c"), "Backend:Users:CreateAccess", "Acceso a la creación de usuarios del backoffice", "USERS", PermissionTypes.Global),
            
            // Case
            new Permission(Guid.Parse("20cbcf7e-5b95-47b2-bfe0-8d7f0e14e0da"), "Backend:Cases:FullAccess", "Acceso total a las casos", "CASES", PermissionTypes.Global),
            new Permission(Guid.Parse("3bfd291d-3e57-4130-90d7-00f86c7af018"), "Backend:Cases:ReadEditAccess", "Acceso de lectura y edición de casos", "CASES", PermissionTypes.Global),
            new Permission(Guid.Parse("95a1722d-07d3-4529-89e4-326eaa4720a8"), "Backend:Cases:ReadOnlyAccess", "Acceso de sólo lectura de casos", "CASES", PermissionTypes.Global),
            new Permission(Guid.Parse("8c97034a-a225-49cd-b0fb-1ae52643c05c"), "Backend:Cases:Delete", "Acceso para eliminar casos", "CASES", PermissionTypes.Global),
            new Permission(Guid.Parse("3bed017b-4c59-44aa-89b7-f18f1e61a96c"), "Backend:Cases:CreateAccess", "Acceso a la creación de casos", "CASES", PermissionTypes.Global),
            new Permission(Guid.Parse("3126368a-1bf5-4a5f-a8f7-d89282ae1eb1"), "Backend:Cases:CloseCaseAccess", "Acceso al cierre de casos", "CASES", PermissionTypes.Global),
            new Permission(Guid.Parse("abfa49e5-d29d-4e7c-ba02-c6459419610c"), "Backend:Cases:InformationCaseAccess", "Acceso para agregar mas información al casos", "CASES", PermissionTypes.Global),
            new Permission(Guid.Parse("a33381b3-3b08-469b-b2fb-c5471f030047"), "Backend:Cases:ExtendCaseAccess", "Acceso a prorrogar un casos", "CASES", PermissionTypes.Global),
            // OriginDocument
            new Permission(Guid.Parse("4bcecb40-1b79-48d2-ab09-80499ded70ed"), "Backend:OriginDocument:FullAccess", "Acceso total a catálogo origen de documentos", "ORIGINDOCUMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("c66f0f7b-10a0-4a39-a04f-8488259e2171"), "Backend:OriginDocument:ReadEditAccess", "Acceso de lectura y edición de catálogo origen de documentos", "ORIGINDOCUMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("f3e1fc5c-d5d3-46e0-bf4d-6ee6b694c564"), "Backend:OriginDocument:ReadOnlyAccess", "Acceso de sólo lectura de catálogo origen de documentos", "ORIGINDOCUMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("1fa956bd-fa4f-449b-9dd1-2643b3e622c9"), "Backend:OriginDocument:Delete", "Acceso para eliminar catálogo origen de documentos", "ORIGINDOCUMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("25643db5-4007-4e80-a8bc-59d7b96d83de"), "Backend:OriginDocument:CreateAccess", "Acceso a la creación de catálogo origen de documentos", "ORIGINDOCUMENT", PermissionTypes.Global),
            // Materials
            new Permission(Guid.Parse("216ef86e-8463-4a1a-8528-a6a27f560fcc"), "Backend:Brand:FullAccess", "Acceso total a las entidades bancarias", "BRANDS", PermissionTypes.Global),
            new Permission(Guid.Parse("2d095278-5e22-4930-8a3b-cf85cb821778"), "Backend:Brand:ReadEditAccess", "Acceso de lectura y edición de entidades bancarias", "BRANDS", PermissionTypes.Global),
            new Permission(Guid.Parse("fad6421f-5f67-4aaa-9842-c1247a51e3b1"), "Backend:Brand:ReadOnlyAccess", "Acceso de sólo lectura de entidades bancarias", "BRANDS", PermissionTypes.Global),
            new Permission(Guid.Parse("f12185ce-7869-4878-aacb-fa9beade561e"), "Backend:Brand:Delete", "Acceso para eliminar las entidades bancarias de un evento", "BRANDS", PermissionTypes.Global),
            new Permission(Guid.Parse("75cb0b4e-3014-4ed6-8cac-080f6e0522ef"), "Backend:Brand:CreateAccess", "Acceso a la creación de las entidades bancarias de un evento", "BRANDS", PermissionTypes.Global),
            // Tools
            new Permission(Guid.Parse("d88b3db0-67ab-4cc4-a03b-11bd770252f7"), "Backend:TypeRequirement:FullAccess", "Acceso total a los tipos de requerimiento", "TYPEREQUIREMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("c9533242-c907-4649-ae2a-bdaf6b4f883b"), "Backend:TypeRequirement:ReadEditAccess", "Acceso de lectura y edición de tipos de requerimiento", "TYPEREQUIREMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("08cd8a62-1a32-4207-81d8-758eb6c918a2"), "Backend:TypeRequirement:ReadOnlyAccess", "Acceso de sólo lectura de tipos de requerimiento", "TYPEREQUIREMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("67331ab5-cd2a-409e-a93c-332b644799ba"), "Backend:TypeRequirement:Delete", "Acceso a eliminar un tipos de requerimiento", "TYPEREQUIREMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("5febc3c4-8d3b-4e20-a327-d70d09ee7f58"), "Backend:TypeRequirement:CreateAccess", "Acceso a la creación de tipos de requerimiento", "TYPEREQUIREMENT", PermissionTypes.Global),
            // Viatics
            new Permission(Guid.Parse("30b715c6-e2a3-4d9e-8e4d-b11bd1ff03a2"), "Backend:Department:FullAccess", "Acceso total a los departamentos", "DEPARTMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("4e0becaf-ae7e-4464-a07e-710dffd008b2"), "Backend:Department:ReadEditAccess", "Acceso de lectura y edición de departamentos", "DEPARTMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("f84f8a10-3ffa-42f3-ab91-800b2542d79a"), "Backend:Department:ReadOnlyAccess", "Acceso de sólo lectura de departamentos", "DEPARTMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("5a8b1b2e-4fb6-4b4e-b4a2-2ea1de7a2f89"), "Backend:Department:Delete", "Acceso a eliminar un departamentos", "DEPARTMENT", PermissionTypes.Global),
            new Permission(Guid.Parse("8d083952-eedd-4045-b6f9-70f7db8b4277"), "Backend:Department:CreateAccess", "Acceso a la creación de departamentos", "DEPARTMENT", PermissionTypes.Global),
            // Clients
            new Permission(Guid.Parse("284406eb-c3f9-47e0-821c-73f33e616c47"), "Backend:Reminder:FullAccess", "Acceso total a los recordatorios", "REMINDER", PermissionTypes.Global),
            new Permission(Guid.Parse("e95ba6bb-b294-40bc-b16e-9cf4e86f8b85"), "Backend:Reminder:ReadEditAccess", "Acceso de lectura y edición de recordatorios", "REMINDER", PermissionTypes.Global),
            new Permission(Guid.Parse("d9d2efb6-e937-44e2-b261-5fe53e2372b7"), "Backend:Reminder:ReadOnlyAccess", "Acceso de sólo lectura de recordatorios", "REMINDER", PermissionTypes.Global),
            new Permission(Guid.Parse("27e5cebf-c9d6-4efb-9adc-fe3aee6350dc"), "Backend:Reminder:Delete", "Acceso para eliminar las recordatorios", "REMINDER", PermissionTypes.Global),
            new Permission(Guid.Parse("75a78e80-71c0-4d4b-97c6-6b9bbbd1abcd"), "Backend:Reminder:CreateAccess", "Acceso a la creación de las recordatorios", "REMINDER", PermissionTypes.Global),
            // Contacts
            new Permission(Guid.Parse("21f387a2-e4db-4b5f-969f-6827f59d6d6e"), "Backend:StatusCase:FullAccess", "Acceso total a los estados del caso", "STATUSCASE", PermissionTypes.Global),
            new Permission(Guid.Parse("cdb3a640-04da-4283-a96a-ad3892536532"), "Backend:StatusCase:ReadEditAccess", "Acceso de lectura y edición de estados del caso", "STATUSCASE", PermissionTypes.Global),
            new Permission(Guid.Parse("295104fb-f245-4d6d-b5c0-00b6d8412707"), "Backend:StatusCase:ReadOnlyAccess", "Acceso de sólo lectura de estados del caso", "STATUSCASE", PermissionTypes.Global),
            new Permission(Guid.Parse("b0bd7159-1294-42e2-8c6c-50c6045a2b90"), "Backend:StatusCase:Delete", "Acceso para eliminar las estados del caso", "STATUSCASE", PermissionTypes.Global),
            new Permission(Guid.Parse("6af9e24d-543b-4117-991e-79ea0a632561"), "Backend:StatusCase:CreateAccess", "Acceso a la creación de las estados del caso", "STATUSCASE", PermissionTypes.Global),
            // Province
            new Permission(Guid.Parse("6d179691-0ec9-466d-8687-49108aabad8b"), "Backend:Provinces:FullAccess", "Acceso total a las provincias", "PROVINCES", PermissionTypes.Global),
            new Permission(Guid.Parse("942b56fd-0f9a-45fc-804b-b671c803071d"), "Backend:Provinces:ReadEditAccess", "Acceso de lectura y edición de provincias", "PROVINCES", PermissionTypes.Global),
            new Permission(Guid.Parse("1f2d58aa-3e71-4f5a-934d-f7f5c151d5ec"), "Backend:Provinces:ReadOnlyAccess", "Acceso de sólo lectura de provincias", "PROVINCES", PermissionTypes.Global),
            new Permission(Guid.Parse("e10aaf89-1b6a-466b-b625-a51b70c9551a"), "Backend:Provinces:Delete", "Acceso para eliminar las provincias", "PROVINCES", PermissionTypes.Global),
            new Permission(Guid.Parse("497cd068-51ca-451c-a245-6a602266c987"), "Backend:Provinces:CreateAccess", "Acceso a la creación de las provincias", "PROVINCES", PermissionTypes.Global),
            // Cities
            new Permission(Guid.Parse("6224cff2-fd84-4678-a20e-da842814d0df"), "Backend:StatusCaseSecretary:FullAccess", "Acceso total a los estados de casos de secretaria", "STATUSCASESECRETARY", PermissionTypes.Global),
            new Permission(Guid.Parse("6d7edc27-9932-49af-a8ef-335ae1b21826"), "Backend:StatusCaseSecretary:ReadEditAccess", "Acceso de lectura y edición de estados de casos de secretaria", "STATUSCASESECRETARY", PermissionTypes.Global),
            new Permission(Guid.Parse("032907f3-6402-4462-bc21-17bc467f1c95"), "Backend:StatusCaseSecretary:ReadOnlyAccess", "Acceso de sólo lectura de estados de casos de secretaria", "STATUSCASESECRETARY", PermissionTypes.Global),
            new Permission(Guid.Parse("0bf0e12e-b87b-4bde-a9d9-8574463d4760"), "Backend:StatusCaseSecretary:Delete", "Acceso para eliminar los estados de casos de secretaria", "STATUSCASESECRETARY", PermissionTypes.Global),
            new Permission(Guid.Parse("a141b5f8-26ad-41f1-a8d1-07b7566bffef"), "Backend:StatusCaseSecretary:CreateAccess", "Acceso a la creación de los estados de casos de secretaria", "STATUSCASESECRETARY", PermissionTypes.Global),
            // Unities
            new Permission(Guid.Parse("6247ffa8-fbe2-4063-8187-47ce30a28fa3"), "Backend:MyCase:FullAccess", "Acceso total a los casos asignados", "MYCASE", PermissionTypes.Global),
            new Permission(Guid.Parse("dad67e66-4b3d-4080-97a4-29cfe16f2532"), "Backend:MyCase:ReadEditAccess", "Acceso de lectura y edición de casos asignados", "MYCASE", PermissionTypes.Global),
            new Permission(Guid.Parse("faa13d8b-8409-4521-9233-438e8a3cc8a5"), "Backend:MyCase:ReadOnlyAccess", "Acceso de sólo lectura de casos asignados", "MYCASE", PermissionTypes.Global),
            new Permission(Guid.Parse("95eaec57-732c-4182-ab72-163f35d843dc"), "Backend:MyCase:Delete", "Acceso para eliminar los casos asignados", "MYCASE", PermissionTypes.Global),
            new Permission(Guid.Parse("4f349889-ffcf-4c55-9d4d-0b07e4ba2b07"), "Backend:MyCase:CreateAccess", "Acceso a la creación de los casos asignados", "MYCASE", PermissionTypes.Global),
            // Profiles
            new Permission(Guid.Parse("6ae83a95-6e26-453d-9546-12090ab917e3"), "Backend:Profiles:FullAccess", "Acceso total a los perfiles disponibles", "PROFILES", PermissionTypes.Global),
            new Permission(Guid.Parse("bcd4bd0e-e177-4cf1-94a8-725ac56115ef"), "Backend:Profiles:ReadEditAccess", "Acceso de sólo lectura a los perfiles disponibles", "PROFILES", PermissionTypes.Global),
            new Permission(Guid.Parse("c4b67360-a258-4249-8dd5-80ac3fa6dcf0"), "Backend:Profiles:ReadOnlyAccess", "Acceso para listar los perfiles disponibles", "PROFILES", PermissionTypes.Global),
            new Permission(Guid.Parse("2fcef7b1-c180-4400-a31b-d83759b103c2"), "Backend:Profiles:Delete", "Acceso para eliminar los perfiles disponibles", "PROFILES", PermissionTypes.Global),
            new Permission(Guid.Parse("36cdc761-1162-413a-abd3-aac0316bb469"), "Backend:Profiles:CreateAccess", "Acceso a creación de los perfiles", "PROFILES", PermissionTypes.Global)
        );

        context.SaveChangesAsync().Wait();
    }
}