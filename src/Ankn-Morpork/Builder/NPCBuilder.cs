using Ankn_Morpork.NPCs;
using Ankn_Morpork.NPCsInterface;

namespace Ankn_Morpork.Builder
{
    public class NPCBuilder
    {
        public static IGuildNPC CreateNpc(int randomNpcNumber)
        {
            if (randomNpcNumber > 0 && randomNpcNumber < 5)
            {
                switch (randomNpcNumber)
                {
                    case 1:
                        return new Thief();
                    case 2:
                        return new Clown();
                    case 3:
                        return new Assasin();
                    case 4:
                        return new Beggar();
                }
            }

            return null;
        }
    }
}
