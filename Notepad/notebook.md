### code

animation assigns in start methods

Action handler = (a, b) switch
{
    (false, false) => DoThis();
    (false, true)  => Do001,
    (true, false)  => Do010,
    (true, true)   => Do011,
};

handler(a, b);

        ((a, b) switch
        {
            (false, false) => (Action)(() =>
            {
                // 00 case
                Console.WriteLine("a=false, b=false");
            }),

            (false, true) => () =>
            {
                // 01 case
                Console.WriteLine("a=false, b=true");
            },

            (true, false) => () =>
            {
                // 10 case
                Console.WriteLine("a=true, b=false");
            },

            (true, true) => () =>
            {
                // 11 case
                Console.WriteLine("a=true, b=true");
            },
        })();

void StartMoving()
{
    Action action;

    var key = (isLookingRight, isSprintingRight);

    switch (key)
    {
        case (false, false):
            action = () => Debug.Log("SprintLeftToLeft");
            break;

        case (false, true):
            action = () => Debug.Log("SprintLeftToRight");
            break;

        case (true, false):
            action = () => Debug.Log("SprintRightToLeft");
            break;

        case (true, true):
            action = () => Debug.Log("SprintRightToRight");
            break;

        default:
            throw new Exception("Unhandled combination");
    }

    action();
}