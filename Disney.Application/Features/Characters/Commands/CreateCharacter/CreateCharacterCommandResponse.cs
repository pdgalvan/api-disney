using Disney.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Commands.CreateCharacter
{
    public class CreateCharacterCommandResponse : BaseResponse
    {
        public CreateCharacterCommandResponse()
            :base()
        {

        }

        public  Guid CharacterId { get; set; }
    }
}
