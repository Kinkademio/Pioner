using System.Collections.Generic;
using UnityEngine;

public class SovetGlove : Weapon
{
    [SerializeField] Pool mug;
    [SerializeField] float shootPower;
    [SerializeField] List<Module> _avalibleModules;
    [SerializeField] AvalibleModules modulesUI;
    [SerializeField] BulletController bulletController;

    private Module _activeModule;

    private void Update()
    {
        this.bulletController.UpdateBulletCount(mug.GetCountOfPoolObjects(), mug.GetMaxCountOfPoolObjects());

        for(int i=0;i<_avalibleModules.Count; i++)
        {
            if (Input.GetKey((KeyCode) 49 + i)) 
            {
                this._activeModule = _avalibleModules[i];
                this.modulesUI.Initialize(this._avalibleModules, this._activeModule);
            }
        }
    }


    /**
     * Возвращает активный модуль перчатки
     */
    public Module GetCurrentModule()
    {
        return _activeModule;
    }

    /**
    * Устанавливает активынй модуль
    */
    public void SetCurrentModule(Module module)
    {
        this._activeModule = module;
    }

    /**
     * Добавляет модуль в функционал перчаки
     */
    public void AddModule(Module module)
    {
        if (!this._avalibleModules.Contains(module))
        {
            this._avalibleModules.Add(module);

            if (!this._activeModule)
            {
                this._activeModule = module;
            }
        }
        //Обновляем интерфейс, так нельзя, но времени уже нет проектировать :/
        this.modulesUI.Initialize(this._avalibleModules, this._activeModule);
    }

    /**
     * Удаляет модуль из доступных
     */
    public void RemoveModule(Module module)
    {
        this._avalibleModules.Remove(module);
        this._activeModule = this._avalibleModules[0];
        //Обновляем интерфейс, так нельзя, но времени уже нет проектировать :/
        this.modulesUI.Initialize(this._avalibleModules, this._activeModule);
    }

    /**
     * Получить все модули перчатки
     */
    public List<Module> GetAllModules()
    {
        return this._avalibleModules;
    }
    
    public new void Attack()
    {
        //Стреляем если магазин не пустной
        if(this.mug.GetCountOfPoolObjects() > 0 && _activeModule != null)
        {
            GameObject bullet = this.mug.GetObjFromPool(this.gameObject.transform.position);
            bullet.GetComponent<ElementalBullet>().Initialize(this._activeModule.GetEffect());

            //Направление атаки
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal") * this.shootPower, 0), ForceMode2D.Impulse);
        }
    }
}
