namespace Helpdesk.Core.Dtos.Outputs
{

    public class AgencyListDtoOut : AgencySearchDtoOut
    {
        //REsultado de la busqueda
        public List<AgencyDtoOut>? ListAgencies { get; set; }
    }
}