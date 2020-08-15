// 衝突時に実行
protected override void OnCollision(CollidableObject obj)
{
    // 衝突対象が敵か敵の弾だったら
    if (obj is Enemy || obj is EnemyBullet)
    {
        // 自身を親から削除
        Parent.RemoveChildNode(this);
    }
}