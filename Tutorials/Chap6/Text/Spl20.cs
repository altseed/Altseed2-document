using Altseed2;

namespace Tutorial
{
    // 隕石
    public class Meteor : Enemy
    {
        // フレーム毎の移動速度
        private Vector2F velocity;

+       // HP
+       private int HP = 3;

        // コンストラクタ、OnUpdate略

+        protected override void OnCollision(CollidableObject obj)
+        {
+           // 衝突したのが自機弾だったら
+           if (obj is PlayerBullet)
+           {
+               // HPを1減らす
+               HP--;
+               // HPが0になったらEnemyクラスのOnCollisionを呼び出して削除
+               if (HP == 0)
+               {
+                  base.OnCollision(obj);
+              }
+           }
+       }
+   }
}