using System.Collections.Generic;
using Altseed;

namespace Tutorial
{
    // 衝突可能なオブジェクト(円形)
    public class CollidableObject : SpriteNode
    {
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

        // エンジンに追加された時に実行
        protected override void OnAdded()
        {
            // コライダのコレクションに自身を追加
            objects.Add(this);
        }

        // エンジンから削除された時に実行
        protected override void OnRemoved()
        {
            // コライダのコレクションから自身を削除
            objects.Remove(this);
        }

        // フレーム毎に実行
        protected override void OnUpdate()
        {
            // フラグが成立時に衝突判定を実行
            if (doSurvey)
            {
                Survey();
            }

            // コライダの座標を更新
            collider.Position = Position;
        }

        // 衝突時に実行
        private void CollideWith(CollidableObject obj)
        {
            // nullだったら終了
            if (obj == null)
            {
                return;
            }

            // 衝突対象がSurveyを実行しないオブジェクトだった場合，相手のOnCollisionも実行
            if (!obj.doSurvey)
            {
                obj.OnCollision(this);
            }

            // 自身のOnCollisiionを実行
            OnCollision(obj);
        }

        // 衝突時に実行される内容をオーバーライドして設定できる
        protected virtual void OnCollision(CollidableObject obj)
        {

        }

        // 画面外に出た時自身を消去
        protected void RemoveMyselfIfOutOfWindow()
        {
            var halfSize = Texture.Size / 2;
            if (Position.X < -halfSize.X
                || Position.X > Engine.WindowSize.X + halfSize.X
                || Position.Y < -halfSize.Y
                || Position.Y > Engine.WindowSize.Y + halfSize.Y)
            {
                // 自身を削除
                Parent?.RemoveChildNode(this);
            }
        }

        // 衝突判定を調査する
        private void Survey()
        {
            // objects内の全オブジェクトを検索し，衝突が確認されたオブジェクト間でCollideWithを実行
            foreach (var obj in objects)
                if (collider.GetIsCollidedWith(obj.collider))
                    CollideWith(obj);
        }
    }
}
