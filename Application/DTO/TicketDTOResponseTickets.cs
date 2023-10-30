namespace Application.DTO
{
    public class TicketDTOResponseTickets
    {
        public List<TicketDTOResponseIDTicket> Tickets { get; set; }
        public FuncionDTOResponse Funcion { get; set; }
        public string Usuario { get; set; }
    }
}