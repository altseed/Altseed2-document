// 衝突時に実行
protected override void OnCollision(CollidableObject obj)
{
    // 衝突対象が敵だったら自身を削除
    if (obj is Enemy)
    {
        Parent?.RemoveChildNode(this);
    }
}