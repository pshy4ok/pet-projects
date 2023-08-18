namespace MortalKombat;

public class BattleLogic
{
    private static int _playerHp = 100;
    private static int _computerHp = 100;
    private static readonly Random Random = new ();

    private static Logger _logger = new ();

    public static void RunBattle()
    {
        var isPlayerTurn = true;
        var dmg = Random.Next(15, 30);
        var doubleDmg = 2 * dmg;

        _logger.Log("MORTAL COMBAT SIMULATOR\n");
        _logger.Log("FIGHT\n");
        _logger.Log($"\nYour HP: {_playerHp} || Computer HP: {_computerHp}");
        while (_playerHp > 0 && _computerHp > 0)
        {
            if (isPlayerTurn)
            {
                _logger.Log(
                    $"\nChoose the type of your attack: \nl - light attack (15-25 damage) || h - heavy attack (30-50 damage, but you will skip the next move!)");
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

                        _playerHp -= Random.Next(15, 30);
                        _logger.Log(
                            $"\nYou skipped the move! Computer dealt {dmg} damage to you! You have {_playerHp} now!");
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
            _logger.Log("\nYou are a looser! Computer wins!\n");
        }
        else if (_computerHp <= 0)
        {
            _logger.Log("\nExcellent! You win!\n");
        }
    }
}