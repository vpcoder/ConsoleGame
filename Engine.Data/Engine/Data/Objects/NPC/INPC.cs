

namespace Engine.Data
{

    public interface INPC : ICharacter
    {

        string Name { get; set; }

        CharacterType Character { get; set; }

        Sprite Target { get; set; }

    }

}
