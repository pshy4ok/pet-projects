namespace MortalKombat;

public class BattleLogic
{
    private static int _playerHp = 100;
    private static int _computerHp = 100;
    private static readonly Random Random = new();
    private static Logger _logger = new();

    public static void RunBattle()
    {
        var isPlayerTurn = Random.Next(2) == 0;

        _logger.Log("MORTAL COMBAT SIMULATOR\n");
        
        _logger.Log("Type 'start' to begin the game or 'q' to quit:");
        var menuMessage = InputReader.ReadInput();
        if (menuMessage.ToLower() == "start")
        {
            _logger.Log("\nFIGHT!");
        }
        else if (menuMessage.ToLower() == "q")
        {
            _logger.Log("\nSee you soon!");
            return;
        }
        
        while (_playerHp > 0 && _computerHp > 0)
        {
            var dmg = Random.Next(15, 30);
            var doubleDmg = 2 * dmg;

            if (isPlayerTurn)
            {
                _logger.Log($"\nYour HP: {_playerHp} || Computer HP: {_computerHp}");
                _logger.Log(
                    $"\nChoose the type of your attack: \nl - light attack (15-30 damage) || h - heavy attack (2x damage from the default value, but you will skip the next move!)");
                var attackType = InputReader.ReadInput();
                switch (attackType.ToLower())
                {
                    case "l":
                        _computerHp -= dmg;
                        _logger.Log(
                            $"\nGood punch, you dealt {dmg} damage to computer! Computer has {_computerHp} HP now!");
                        break;
                    case "h":
                        _computerHp -= doubleDmg;
                        _logger.Log(
                            $"\nFatality! You dealt {doubleDmg} damage to computer! Computer has {_computerHp} HP now! You will skip the next move!");
                        if (_computerHp > 0)
                        {
                            _playerHp -= Random.Next(15, 30);
                            _logger.Log(
                                $"\nYou skipped the move! Computer dealt {dmg} damage to you! You have {_playerHp} now!");
                        }
                        else
                        {
                            _logger.Log("\nExcellent! You win!");
                            return;
                        }

                        break;
                    default:
                        _logger.Log("\nWrong move! Please try again!");
                        continue;
                }
            }
            else
            {
                _playerHp -= dmg;
                _logger.Log($"\nComputer dealt {dmg} damage to you! You have {_playerHp} now!");
            }

            isPlayerTurn = !isPlayerTurn;
        }

        if (_playerHp <= 0)
        {
            _logger.Log("\nYou are a looser! Computer wins!");
        }
        else
        {
            _logger.Log("\nExcellent! You win!");
        }
    }
}