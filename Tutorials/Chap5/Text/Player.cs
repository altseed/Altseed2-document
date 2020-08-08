using Altseed2;

namespace Tutorial
{
    // プレイヤーのクラス
    public class Player : SpriteNode
    {
        // ================================================================
        // 省略
        // ================================================================
    
        // ショット
        private void Shot()
        {
            // Zキーでショットを放つ
            if (Engine.Keyboard.GetKeyState(Key.Z) == ButtonState.Push)
            {
+               Parent.AddChildNode(new PlayerBullet(Position));

-               Parent.AddChildNode(new Bullet(Position + CenterPosition, new Vector2F(10f, 0.0f)));
            }
        }
    }
}
