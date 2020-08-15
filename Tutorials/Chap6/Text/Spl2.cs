// コライダのコレクション
public static HashSet<CollidableObject> objects = new HashSet<CollidableObject>();

// コライダ
protected CircleCollider collider = new CircleCollider();

// OnUpdate内で衝突判定を調査するかどうか
protected bool doSurvey;

// 所属するメインノードへの参照
public MainNode mainNode;

// コンストラクタ
public CollidableObject(MainNode mainNode, Vector2F position)
{
    // メインノードへの参照を設定
    this.mainNode = mainNode;

    // コライダの座標を設定
    collider.Position = position;

    // 座標を設定
    Position = position;
}