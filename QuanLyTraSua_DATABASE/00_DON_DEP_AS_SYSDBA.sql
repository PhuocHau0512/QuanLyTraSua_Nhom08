/* ================================================================================
-- TEP 0: 00_DON_DEP_AS_SYSDBA.sql
-- CHAY VOI QUYEN: SYS AS SYSDBA
================================================================================
*/

-- Chuyen sang PDB 'PDBORCL'
ALTER SESSION SET CONTAINER = PDBORCL;
ALTER SESSION SET "_ORACLE_SCRIPT"= true;

DROP ROLE ROLE_NHANVIEN_BANHANG;
DROP ROLE ROLE_QUANLY_KHO;
DROP ROLE ROLE_ADMIN_HT;

/* ----- 1. XOA CHINH SACH OLS ----- */
BEGIN
   SA_SYSDBA.DROP_POLICY(
     policy_name => 'QLTS_POLICY',
     drop_column => TRUE
   );
EXCEPTION
   WHEN OTHERS THEN
      IF SQLCODE = -30752 THEN -- (Loi: Chinh sach khong ton tai)
         DBMS_OUTPUT.PUT_LINE('Chinh sach QLTS_POLICY khong ton tai, bo qua.');
      ELSE
         RAISE;
      END IF;
END;
/

/* ----- 2. XOA USER QLTS VA TAT CA DOI TUONG LIEN QUAN ----- */
DECLARE
  v_user_exists NUMBER;
BEGIN
  SELECT COUNT(1) INTO v_user_exists FROM dba_users WHERE username = 'QLTS';
  IF v_user_exists > 0 THEN
    EXECUTE IMMEDIATE 'DROP USER QLTS CASCADE';
    DBMS_OUTPUT.PUT_LINE('Da xoa user QLTS CASCADE.');
  ELSE
    DBMS_OUTPUT.PUT_LINE('User QLTS khong ton tai, bo qua.');
  END IF;
END;
/

/* ----- 3. XOA PROFILE ----- */
DECLARE
  v_profile_exists NUMBER;
BEGIN
  SELECT COUNT(1) INTO v_profile_exists FROM dba_profiles WHERE profile = 'NV_TRA_SUA_PROFILE';
  IF v_profile_exists > 0 THEN
    EXECUTE IMMEDIATE 'DROP PROFILE NV_TRA_SUA_PROFILE CASCADE';
    DBMS_OUTPUT.PUT_LINE('Da xoa profile NV_TRA_SUA_PROFILE.');
  ELSE
    DBMS_OUTPUT.PUT_LINE('Profile NV_TRA_SUA_PROFILE khong ton tai, bo qua.');
  END IF;
END;
/

/* ----- 4. XOA TABLESPACE ----- */
DECLARE
  v_ts_exists NUMBER;
BEGIN
  SELECT COUNT(1) INTO v_ts_exists FROM dba_tablespaces WHERE tablespace_name = 'TS_QUANLYTRASUA';
  IF v_ts_exists > 0 THEN
    EXECUTE IMMEDIATE 'DROP TABLESPACE TS_QUANLYTRASUA INCLUDING CONTENTS AND DATAFILES';
    DBMS_OUTPUT.PUT_LINE('Da xoa tablespace TS_QUANLYTRASUA.');
  ELSE
    DBMS_OUTPUT.PUT_LINE('Tablespace TS_QUANLYTRASUA khong ton tai, bo qua.');
  END IF;
END;
/

COMMIT;
DBMS_OUTPUT.PUT_LINE('Da don dep hoan tat!');