# play-tween
Tweening Library is a Tweening library made for Unity3D inspired by DOTween 

How to Use: (Move Example)
1. add the using of PT on top
2. in the Awake Function transform.PlayMove(Vector3.right, .5f);
3. that is it.

		using PT;
		Awake()
		{
			transform.PlayMove(Vector3.right, .5f);
		}	

you can also add easing to the tween by simply adding

	transform.PlayMove(Vector3.right, .5f).SetEase(EaseType.OutBack);
 
adding a delay is as simple as adding SetDelay(.5f) to the end of the Tween;

	transform.PlayMove(Vector3.right, .5f).SetEase(EaseType.OutBack).SetDelay(.5f);

How to use the Sequence:

    var sequence = PlayTween.GetSequence();
    sequence.Append(Tween);
    sequence.Join(AnotherTween);
    sequence.SetDelay(.5f);

    
Creating a brand new Tween is as simple as 

    TweenVector3.New(
    duration:.5f,
    to:Vector3.right,
    getter:() => Vector3.zero,
    updater:(value, tween) =>
    {
        //update the value
        //target.position = value;
    },
    target:null);

some limitation:
the sequence is lacking some features.

![Unbenanntes Video – Mit Clipchamp erstellt (1)](https://github.com/mooumari/play-tween/assets/75569583/f1f97721-9c2f-442b-904b-1adc3e3a52a0)


![jump](https://github.com/mooumari/play-tween/assets/75569583/7a8f5138-7547-4fad-8419-98a95148c110)
