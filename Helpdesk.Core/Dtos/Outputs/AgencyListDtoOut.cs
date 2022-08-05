namespace Helpdesk.Core.Dtos.Outputs
{

    public class AgencyListDtoOut : PagerDto
    {
        //Resultado de la busqueda
        public List<AgencyDtoOut> ListAgencies { get; set; }
    }
}