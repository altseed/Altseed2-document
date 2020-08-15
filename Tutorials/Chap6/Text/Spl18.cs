// 衝突時に実行
protected override void OnCollision(CollidableObject obj)
{
    // 衝突対象が自機弾だったら
    if (obj is PlayerBullet)
    {
        // 死亡時エフェクトを再生
        Parent.AddChildNode(new DeathEffect(Position));

        // 自身を削除
        Parent.RemoveChildNode(this);
    }
}