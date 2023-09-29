namespace PT
{
    public delegate void TweenUpdater<in T,in TTween>(T value,TTween tween);
    public delegate T TweenGetter<out T>();
}