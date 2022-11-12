namespace WebApi.Controllers
{
    using Application.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Text.Json;

    public class ErrorsResponse
    {
        public IList<string> mensagens { get; }
        public ValidationProblemDetails mensagensDetalhes { get; }

        public ErrorsResponse(string mensagem)
        {
            this.mensagens = new List<string>() { mensagem };
        }

        public ErrorsResponse(IList<string> mensagens)
        {
            this.mensagens = mensagens;
        }

        public ErrorsResponse(Notification notification)
        {
            this.mensagens = notification.Errors;
            mensagensDetalhes = new ValidationProblemDetails(notification.ModelState);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}