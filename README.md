# play-tween
Tweening Library is a Tweening library made for Unity3D inspired by DOTween 

How to Use: (Move Example)
1. using PT;
2. in the Awake Function transform.PlayMove(Vector3.right, .5f);
3. that is it.

you can also add easing to the tween by simply adding transform.PlayMove(Vector3.right, .5f).SetEase(EaseType.OutBack);
adding a delay is as simple as adding SetDelay(.5f) to the end of the Tween;

Creating a brand new Tween is as simple as 

                TweenVector3.New(
                duration:duration,
                to:to,
                getter:() => target.position,
                updater:(value, tween) =>
                {
                    target.position = value;
                },
                target:target);

some limitation:
the sequence is lacking some features.
