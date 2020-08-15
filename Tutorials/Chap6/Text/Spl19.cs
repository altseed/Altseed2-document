// 衝突時に実行
protected override void OnCollision(CollidableObject obj)
{
    // 衝突対象がプレイヤーだったらBulletのOnCollisionを実行して削除
    if (obj is Player)
    {
        Parent?.RemoveChildNode(this);
    }
}