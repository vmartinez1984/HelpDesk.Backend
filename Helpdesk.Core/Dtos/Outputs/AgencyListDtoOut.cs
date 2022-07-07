namespace Helpdesk.Core.Dtos.Outputs
{

    public class AgencyListDtoOut : AgencySearchDtoOut
    {
        //Resultado de la busqueda
        public List<AgencyDtoOut> ListAgencies { get; set; }
    }
}